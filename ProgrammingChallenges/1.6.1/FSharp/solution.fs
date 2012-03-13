printfn "start ..."

let inputs = [(1, 10); (100, 200); (201, 210); (900, 1000)]

let rec cycleLength x length= 
    match x with
    | 1 -> length + 1
    | x when x % 2 =0 -> cycleLength ((/) x 2) ((+) length 1)
    | _ -> cycleLength ((+) ((*) x 3) 1) ((+) length 1)

let cal x y = 
    ([x..y] |> Seq.map (fun num -> cycleLength num 0)) |> Seq.max

let printResult (first, last) =
    printfn "%i %i %i" first last (cal first last)

Seq.iter (printResult) inputs