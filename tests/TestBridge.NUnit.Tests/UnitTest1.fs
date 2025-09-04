module MTP.NUnit.Tests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``I'm an MTP test`` () =
    Assert.Pass()
