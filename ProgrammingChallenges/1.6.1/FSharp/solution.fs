printfn "start ..."

let inputs = [(1, 10); (100, 200); (201, 210); (900, 1000)]

let rec cycleLength x length= 
    let lgt = (+) length 1
    match x with
    | 1 -> lgt
    | x when x % 2 =0 -> cycleLength ((/) x 2) lgt
    | _ -> cycleLength ((+) ((*) x 3) 1) lgt

let cal x y = 
    ([x..y] |> Seq.map (fun num -> cycleLength num 0)) |> Seq.max

let printRange (low, high) =
    printfn "%i %i %i" low high (cal low high)

Seq.iter (printRange) inputs