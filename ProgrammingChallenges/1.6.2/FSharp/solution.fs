open System
open System.Text.RegularExpressions

let inputs = ["4 4";"*...";"....";".*..";"....";"3 5";"**...";".....";".*...";"0 0"]

let (|End|_|) (line:string) =
    let rst = Regex.Match(line, @"^0\s+0$")
    if rst.Success then
       Some [||]
    else
       None

let (|FieldHead|_|) (line:string) =
    let rst = Regex.Match(line, @"^\d\s+\d$")
    if rst.Success then
       let m = Regex.Matches(line, @"\b\d+\b")
       Some [|for r in m ->r.Value|]
    else
       None

let (|Row|_|) (line:string) =
     let rst = Regex.Match(line, @"^[\.*]+$")
     if rst.Success then
        Some [|for c in line -> c|]
     else
        None

let output (field:char array) r c =
   let buffer = Array.create 
   for rIdx in 0..(r-1) do
	 
     for cIdx in 0..(c-1) do
       let ch = field.[rIdx* c+ cIdx]
       if ch ='*' then
       if ch ='*' then
           buffer.
       printf "%A" ch
     printfn " "
   printfn " "


let readLine line field (rsize:int) (csize:int)=
   match line with
   | End _-> output field rsize csize
             (Array.empty, 0, 0)
   | FieldHead [|a;b|]-> output field rsize csize
                         let r =Int32.Parse a
                         let c = Int32.Parse b
                         (Array.empty, r,c)
   | Row s -> ((Array.append field s), rsize, csize)
   | _  -> (Array.empty, 0, 0)

let rec readIn (inputs:string list) (buffer:char array) rsize csize=
   match inputs with
   | [] -> printfn "end"
   | head::tail ->
                   let (b,r,c) =readLine head buffer rsize csize
                   readIn tail b r c
                  
printfn "Start..."

let initBuffer = Array.empty
let initRowSize = 0
let initColumnSize = 0

readIn inputs initBuffer initRowSize initColumnSize