module Tests

open Xunit
open Battleship

[<Fact>]
let ``Tautology`` () = Assert.True(true)

let ship() =  { Size = 2; TopLeft = { X = 1; Y = 1 }; Orientation = Orientation.Vertical }

let board8x8() = new Board2D(8, 8)

let board2x2() = new Board2D(2, 2)

[<Fact>]
let ``can add ship within board's bounds``() = Assert.True(board8x8().AddShip(ship()))

[<Fact>]
let ``cannot add ship out of board's bounds``() = Assert.False(board2x2().AddShip(ship()))

[<Fact>]
let ``when hit once game is not lost``() =
  let board = board8x8()
  board.AddShip(ship()) |> ignore
  board.Hit({ X = 1; Y = 1 }) |> ignore
  Assert.False(board.IsGameLost)

[<Fact>]
let ``when hit twice game is lost``() =
  let board = board8x8()
  board.AddShip(ship()) |> ignore
  board.Hit({ X = 1; Y = 1 }) |> ignore
  board.Hit({ X = 1; Y = 2 }) |> ignore
  Assert.True(board.IsGameLost)
