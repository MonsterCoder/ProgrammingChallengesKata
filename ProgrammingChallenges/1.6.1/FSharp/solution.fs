printfn "start ..."

let inputs = [(1, 10); (100, 200); (201, 210); (900, 1000)]

let cycleLength x = x

let printTuple (first, last) =
    printfn "%i %i %i" first last ((+) first last)

Seq.iter (printTuple) inputs