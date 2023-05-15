namespace MsTestTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    
module NestSomeTests = 
    [<TestClass>]
    type NestedInAModule () =

        [<TestMethod>]
        member this.``This Is Nested`` () =
            Assert.IsTrue(true);