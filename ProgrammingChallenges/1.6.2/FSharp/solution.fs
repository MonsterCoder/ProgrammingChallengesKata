open System
open System.Text.RegularExpressions

let inputs = ["4 4","*...","....",".*..","....","3 5","**...",".....",".*...","0 0"]
s
let (|End|_|) (line:string) =
    let rst = Regex.Match(line, @"^0\s+0$")
    if rst.Success then
       Some line
    else
       None

let (|FieldHead|_|) (line:string) =
    let rst = Regex.Match(line, @"^\d\s+\d$")
    if rst.Success then
       Some line
    else
       None

let (|Row|_|) (line:string) =
     let rst = Regex.Match(line, @"^[\.*]+$")
     if rst.Success then
        Some line
     else
        None

let Classify line =
   match line with
   | End s-> printfn "End %s" s
   | FieldHead s -> printfn "Head %s" s
   | Row s -> printfn "Row %s" s
   | _  -> printfn "Unknown"

printfn "Start..."
Classify "4 4"
Classify "0 0"
Classify "*...."
Classify "*.a..."