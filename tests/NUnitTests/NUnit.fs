module NUnitTests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1IsRenamed () =
    Assert.Pass()

[<Test>]
let IAmATest () =
    Assert.Pass()

[<Test>]
let Added () = 
    ()

module Nested =
    [<Test>]
    let IAmATest () = 
        ()


type ClassBased () =
    [<Test>]
    member _.``Test inside a class instance`` () = 
        ()