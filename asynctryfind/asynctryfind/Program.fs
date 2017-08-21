// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Test
[<EntryPoint>]
let main argv = 
    async {
        let! r = goTest
        match r with
        | Some i -> printfn "%s" i.Name
        | None -> printfn "not found"
    } |> Async.Start
    wait |> Async.Start


    System.Console.ReadLine () |> ignore
    let r2 = goTest2
    match r2 with
        | Some i -> printfn "method2 %s" i.Name
        | None -> printfn "method2 not found"
        
    System.Console.ReadLine () |> ignore


    async {
        let! r = goTest3
        match r with
        | Some i -> printfn "method3 async %s" i.Name
        | None -> printfn "method3 async not found"
    } |> Async.Start
    wait |> Async.Start


    System.Console.ReadLine () |> ignore
    printfn "%A" argv
    0 // return an integer exit code


