module XUnitTests

open System
open Xunit


[<Fact>]
let ``Such test`` () =
    Assert.True(true)


[<Fact>]
let ``Very Slow`` () =
    Threading.Thread.Sleep(5000)
    Assert.True(true)

[<Fact>]
let ``Contains.separator+characters`` () =
    Assert.True(true)

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Such name`` () =
    ()

[<Fact>]
let ``I Fail`` () =
    Assert.True(false)

[<Fact>]
let ``Same name different scope`` () =
    Assert.True(true)

[<Fact(DisplayName="I have a display name")>]
let HasDisplayName () =
    Assert.True(true)

module Nested =

    [<Fact>]
    let ``Same name different scope`` () =
        Assert.True(true)

    [<Fact>]
    let ``Very Nested`` () =
        Assert.True(false)

    module AnotherLayer =
        [<Fact>]
        let ``Bow Wow`` () =
            Assert.True(true)

type ``Class Based`` () =
    [<Fact>]
    let ``I'm part of a class`` () =
        Assert.True(true)

[<Theory>]
[<InlineData(2,2,4)>]
[<InlineData(2,3,4)>]
let theoryTest (x:int) (y:int) (sum:int) =
    Assert.Equal(sum, x+y)

// [<Fact>]
// let Slow1 () =
//     System.Threading.Thread.Sleep(1000)

// [<Fact>]
// let Slow2 () =
//     System.Threading.Thread.Sleep(5000)

[<Fact(Skip = "I'm skipped")>]
let Skipped () =
    Assert.Equal(true, true)

[<Fact>]
let AccessEnv () =
    let envValue = System.Environment.GetEnvironmentVariable "this"
    // let envValue = System.Environment.GetEnvironmentVariable "Ionide_TestValue"
    Assert.Equal("cat", envValue)



module NamesWithFilterChars =

    [<Fact>]
    let ``!`` () = ()
   
    [<Fact>]
    let ``this \ that`` () = ()
   
    [<Fact>]
    let ``~`` () = ()
   
    [<Fact>]
    let ``()`` () = ()
    
    [<Fact>]
    let ``=`` () = ()