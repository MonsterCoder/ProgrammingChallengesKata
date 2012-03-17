open System
open System.Text.RegularExpressions

let inputs = ["4 4","*...","....",".*..","....","3 5","**...",".....",".*...","0 0"]

let (|End|_|) (line:string) =
    let rst = Regex.Match(line, @"^0\s+0$")
    if rst.Success then
       Some []
    else
       None

let (|FieldHead|_|) (line:string) =
    let rst = Regex.Match(line, @"^\d\s+\d$")
    if rst.Success then
       let m = Regex.Matches(line, @"\b\d+\b")
       Some [for r in m ->r.Value]
    else
       None

let (|Row|_|) (line:string) =
     let rst = Regex.Match(line, @"^[\.*]+$")
     if rst.Success then
        Some [for c in line -> c]
     else
        None

let Classify line =
   match line with
   | End s-> printfn "End %A" s
   | FieldHead [a;b]-> printfn "Head %A %A" a  b
   | Row s -> printfn "Row %A" s
   | _  -> printfn "Unknown"

printfn "Start..."

Classify "3 5"
Classify "0 0"
Classify "*...."
Classify "*.a..."