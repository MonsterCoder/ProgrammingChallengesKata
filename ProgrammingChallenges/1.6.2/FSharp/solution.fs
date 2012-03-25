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

let output (arr:char array) r c =
               if arr.Length > 0 then
                  printfn "%A" arr

let Classify line buffer (rnum:int) (cnum:int)=
   match line with
   | End s-> output buffer rnum cnum
             (Array.empty, 0, 0)
   | FieldHead [|a;b|]-> output buffer rnum cnum
                         let r =Int32.Parse a
                         let c = Int32.Parse b
                         (Array.empty, r,c)
   | Row s -> ((Array.append buffer s), rnum,cnum)
   | _  -> (Array.empty, 0, 0)

let rec read (inputs:string list) (buffer:char array) rnum cnum=
   match inputs with
   | [] -> printfn "end"
   | head::tail ->
                   let (b,r,c) =Classify head buffer rnum cnum
                   read tail b r c
                  
printfn "Start..."

let init = Array.empty
read inputs init 0 0