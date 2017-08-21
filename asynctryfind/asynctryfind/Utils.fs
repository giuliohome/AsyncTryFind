module Utils

let tryFind (f : 'T -> Async<bool>) (ts : 'T list) =
    let folder acc t = async {
        let! result = acc
        match result with
        | Some _ -> return result
        | None ->
            let! success = f t
            return if success then Some t else None
    }
 
    List.fold folder (async.Return None) ts

let rec tryFindRec (f : 'T -> Async<bool>) (ts : 'T list) = async {
    match ts with
    | [] -> return None
    | head :: tail ->
        let! r = f head
        if r then return Some head
        else return! tryFind f tail
}

let CoreTryFind (f : 'T -> Async<bool>) (ts : 'T list) =
    ts
    |> Seq.tryFind( fun x -> 
            async { return! f x
            } |> Async.RunSynchronously ) 
