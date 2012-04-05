open System
open System.Text.RegularExpressions

let inputs1 = ["1 4";"*...";"0 0"]
let inputs = ["4 4";"*...";"....";".*..";"....";"3 5";"**...";".....";".*...";"0 0"]

type Line =
    | Controls of int*int
    | Mines of char[]

let parseLine line =
    if Regex.Match(line, @"^\d\s+\d$").Success then
         let a::b::_=[for r in Regex.Matches(line, @"\b\d+\b") ->r.Value |> Int32.Parse]
         Controls(a,b)
    else
         Mines([|for c in line -> c|])

let output = function
       | (row,[||]) -> row
       | (row,[|'*'|]) -> [|'*'|]
           
let rec processInput inputs (buffer:char[]) = 
    match inputs with
       | head::tail -> 
                   match parseLine(head) with
                       |Controls(0,0) -> output([|for i in 0..(buffer.Length-1) -> '.'|],buffer)
                                         
                       |Controls(r,c) -> output([|for i in 0..(buffer.Length-1) -> '.'|],buffer)
                                         processInput tail Array.empty    
                                                               
                       |Mines(row) ->    let b = output(row,buffer)
                                         processInput tail b
        | [] -> buffer
                                         
processInput inputs1 Array.empty  