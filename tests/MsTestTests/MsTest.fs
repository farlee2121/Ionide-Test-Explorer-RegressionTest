namespace MsTestTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    [<DataTestMethod>]
    [<DataRow(2,2,4)>]
    [<DataRow(2,3,5)>]
    member this.theoryTest (x:int, y:int, sum:int) =
        Assert.AreEqual(sum, x + y)
        
module NestSomeTests = 
    [<TestClass>]
    type NestedInAModule () =

        [<TestMethod>]
        member this.``This Is Nested`` () =
            Assert.IsTrue(true);

