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


[<TestCase(2,2,4)>]
[<TestCase(2,3,4)>]
let theoryTest x y sum =
    Assert.AreEqual(sum, x + y)