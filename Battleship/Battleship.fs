namespace Battleship

   open System.Linq

   type Person = Woman | Man
   and Height = int

   type Point2D = { X: int; Y: int }

   type Orientation = Horizontal | Vertical

   type Ship = {Orientation:Orientation; TopLeft:Point2D; Size:int } with
       member this.Points =
            match this.Orientation with
                | Horizontal -> List.map (fun i -> { X = this.TopLeft.X + i; Y = this.TopLeft.Y }) [0 .. this.Size-1] |> Set.ofList
                | Vertical -> List.map (fun i -> { X = this.TopLeft.X; Y = this.TopLeft.Y + i }) [0 .. this.Size-1] |> Set.ofList

   type Board2D(Width: int, Height: int) =
        let mutable Points:Set<Point2D> = Set.empty
        let mutable HitPoints:Set<Point2D> = Set.empty

        member this.AddShip (ship:Ship) = 
            if Points.Intersect(ship.Points).Any() then
                // already occupied: 
                false
            elif ship.Points.Any(fun pt -> pt.X + ship.TopLeft.X >= Width || pt.Y + ship.TopLeft.Y >= Height) then
                // out of bounds:
                false
            else
                for pt in ship.Points do
                    Points <- Points.Add pt
                true

        member this.IsGameLost = Points.IsEmpty

        member this.Hit(pt: Point2D) =
            if HitPoints.Contains pt then
                true
            else
                match Points.Contains pt with
                   | true -> 
                       Points <- Points.Remove(pt)
                       HitPoints <- HitPoints.Add(pt)
                       true
                   | false -> false
