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


[<TestFixture>]
type ClassBased () =
    [<Test>]
    let IAmATest () = 
        ()