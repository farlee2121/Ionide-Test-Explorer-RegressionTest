module Tests

open Expecto
open System

let testCase' = testCase;
let test' = test;

let testProperty' name f = testPropertyWithConfig { FsCheckConfig.defaultConfig with arbitrary = []} name f

let theory (name:string) (cases: #seq<'T>) (fTest: 'T -> 'U) =
  let dataToTest caseData =
    testCase (string caseData) <| fun () ->
      fTest caseData |> ignore
      
  testList name (cases |> Seq.map dataToTest |> List.ofSeq)
  
let theoryWithResult (name:string) (cases: #seq<('T*'U)>) (fTest: 'T -> 'U) =
  let dataToTest (caseData,expected) =
    testCase (string (caseData, expected)) <| fun () ->
      let actual = fTest caseData
      Expect.equal actual expected $"Input: {caseData} \nExpected {expected} \nActual: {actual}"
  
  testList name (cases |> Seq.map dataToTest |> List.ofSeq)

type ICrudAPI<'a> = {
  Get: Guid -> 'a option
  Save: Guid -> 'a -> unit
  ListAll: unit -> 'a list
  Generate: unit -> 'a
}
let reusableTestSuite (variantExplanation: string) (sutFactory: unit -> ICrudAPI<'a>) =
  testList $"Can CRUD for: {variantExplanation}" [
    testCase "Geting an unsaved item returns none" <| fun () ->
      let sut = sutFactory ()
      Expect.equal (sut.Get (Guid.NewGuid())) None ""

    testCase "Get and save can roundtrip" <| fun () ->
      let sut = sutFactory ()
      let expected = sut.Generate ()
      let id = Guid.NewGuid()
      sut.Save id expected
      Expect.equal (sut.Get id) (Some expected) ""

    let setEqual actual expected message = 
      let likeness (list: 'a list) = 
        {| Length = list.Length; UniqueValues = set list|}
      Expect.equal (likeness actual) (likeness expected) message

    testCase "List should include all saved items" <| fun () ->
      let sut = sutFactory ()
      let expected = List.init 5 (fun _ -> sut.Generate ())
      expected |> List.iter (fun x -> sut.Save (Guid.NewGuid()) x)
    
      setEqual (sut.ListAll ()) expected ""
  ]


let InMemoryCrudAPIFactory () =
  let store = Collections.Generic.Dictionary<Guid, int> () 

  {
    Generate = (fun () -> Random.Shared.Next())
    Get = (fun id -> if store.ContainsKey id then Some store[id] else None)
    Save = (fun id value -> store[id] <- value)
    ListAll = (fun () -> store.Values |> List.ofSeq)
  }

type RootClass() = class end
type ClassA(i: int) = 
  let i = i
type ClassB() = inherit RootClass()

[<Tests>]
let tests =
  testList "ExpectoTests" [
    
    testCase "Contains -- in the name, which we use an id separator" <| fun () ->
        ()

    testList "Wrapped test methods" [
      testCase' "Methods that call other test methods still show in test explorer" <| fun _ ->
        ()

      test' "That includes test builder wrappers" {
        ()
      }

      theoryWithResult "This repeats a test with different specified data" [
        (1,2),3
        (2,2),4
        (1,2),4
      ] <| fun (n,m) ->
        n + m

      testProperty' "A property tests with shared custom config" <| fun (i: int) ->
        true

    ]
    
    testTheory "New official theory test" [
      (2,2),4
      (2,3),5
    ] <| fun ((x,y),sum) ->
      Expect.equal (x+y) sum ""


    reusableTestSuite "InMemoryCrudAPI" InMemoryCrudAPIFactory

    testCase "Contains+separator.characters" <| fun _ ->
      let subject = true
      Expect.isTrue subject "I compute, therefore I am."

    // testCase "Access to env" <| fun _ ->
    //   let writeEnvVars (d:System.Collections.IDictionary) =
    //     let formatted =
    //       d.Keys 
    //       |> Seq.cast<string>
    //       |> Seq.map (fun key -> $"{key}: {d[key]}")
    //     System.IO.File.AppendAllLines("C:/users/farle/downloads/env.txt", formatted)
    //   let s = System.Environment.GetEnvironmentVariables()
    //   writeEnvVars s
    //   let envValue = System.Environment.GetEnvironmentVariable "this"
    //   // let envValue = System.Environment.GetEnvironmentVariable "Ionide_TestValue"
    //   Expect.equal envValue "cat" ""

    testCase "universe exists (╭ರᴥ•́) boi" <| fun _ ->
      let subject = true
      Expect.isTrue subject "I compute, therefore I am."

    testCase "contains \"quotes\"" <| fun _ ->
      let subject = true
      Expect.isTrue subject "I compute, therefore I am."

    testCase "when true is not (should fail)" <| fun _ ->
      let subject = false
      Expect.isTrue subject "I should fail because the subject is false"

    testCase "I'm always fail (should fail)" <| fun _ ->
      Tests.failtest "This was expected..."

    testCase "I'm skipped (should skip)" <| fun _ ->
      Tests.skiptest "Yup, waiting for a sunny day..."

    testCase "contains things" <| fun _ ->
      Expect.containsAll [| 2; 3; 4 |] [| 2; 4 |]
                         "This is the case; {2,3,4} contains {2,4}"

    testCase "contains things (should fail)" <| fun _ ->
      Expect.containsAll [| 2; 3; 4 |] [| 2; 4; 1 |]
                         "Expecting we have one (1) in there"

    testCase "Sometimes I want to ༼ノಠل͟ಠ༽ノ ︵ ┻━┻" <| fun _ ->
      Expect.equal "abcdëf" "abcdef" "These should equal"

    
    test "I am (should fail)" {
      "╰〳 ಠ 益 ಠೃ 〵╯" |> Expect.equal true false
    }

    testList "Deeply nest" [
      testList "Another layer" [
        testCase "Bottom of nesting" (fun _ -> ())
      ]
    ]
  ]

let compose1 = testList "Not directly in parent"  [
  testCase "I pass and can rename" (fun _ -> ())
  test "Me too" { ()}
]

let compose2 = testList "Also not directly in parent"  [
  testCase "Nya aa" (fun _ -> ())
  test "Woof" { ()}
  testList "Deeper nesting boi" [
    testCase "Baaa" (fun _ -> ())

    testList "So deep" [
      testCase "Baaaaaaaaa" (fun _ -> ())
    ]
  ]
]

[<Tests>]
let t = testList "Composed test list?" [
  compose1
  compose2
]

[<Tests>]
let t2 = testList "Composed test lists - 2" [
  compose1
  compose2
]