module Test


open Utils

type Image() =
  let mutable name = ""
  member this.Name 
    with get() = name
    and set value = name <- value
    

let fakeF (image : Image)  = async {
    do! Async.Sleep 1000
    return image.Name.StartsWith("A")
}


let list = [|"Boring";"thing";"at";"Another";"time"|] 
        |> Seq.map(fun s -> 
            let i = Image()
            i.Name <- s
            i
            )
        |> Seq.toList

let goTest  =
    list |> tryFindRec(fakeF) 
    
let goTest2 = 
    list |>  CoreTryFind(fakeF) 


let goTest3 = 
    list |> AsyncCoreTryFind(fakeF)

