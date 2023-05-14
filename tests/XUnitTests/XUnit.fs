module XUnitTests

open System
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

let ``Such test`` () =
    Assert.True(true)

let ``I Fail`` () =
    Assert.True(false)
    
