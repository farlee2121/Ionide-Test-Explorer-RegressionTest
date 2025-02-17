module ExpectoLogging

open Expecto
open Expecto.Logging
open Expecto.Logging.Message

let logger = Log.create "Logger"

[<Tests>]
let tests =
    testList
        "LoggingTests"
        ([ 1..10 ]
         |> List.map (fun i ->
             testCase $"failing test {i}" (fun () ->
                 let logger = Log.create $"failing test {i}"
                 logger.info (eventX "Info from test before {testNumber}" >> setField "testNumber" i)
                 Expect.isFalse true "Expected false")))
