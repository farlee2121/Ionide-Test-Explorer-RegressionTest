module MTPv2NUnitTests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let IHaveSuccessOutput () =
    Assert.Pass("Success output")

[<Test>]
let Added () = 
    ()

[<Test>]
let SameNameDifferentScope () =
    Assert.Pass()

module Nested =
    [<Test>]
    let SameNameDifferentScope () = 
        ()

type ClassBased () =
    [<Test>]
    member _.``Test inside a class instance`` () = 
        ()

[<TestCase(2,2,4)>]
[<TestCase(2,3,4)>]
let theoryTest (x:int) (y: int) (sum: int) =
    Assert.That(sum, Is.EqualTo((x + y)))

[<Test>]
let ``Contains seperators + and . but one name`` () =
    Assert.That( true)