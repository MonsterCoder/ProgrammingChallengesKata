open System
open System.Text.RegularExpressions

type Line =
    | Controls of int*int
    | Mines of char list

let parseLine line =
    if Regex.Match(line, @"^\d\s+\d$").Success then
         let [a;b]=[for r in Regex.Matches(line, @"\b\d+\b") ->r.Value |> Int32.Parse]
         Controls(a,b)
    else
         Mines([for c in line -> c])

let add = function
        | (n,'*') -> '*'
        | (n,'.') -> n.ToString().Chars(0)
        | (n,i) -> ((Int32.Parse (i.ToString())) + n).ToString().Chars(0)

let count = function
        |'*' -> 1
        | _ -> 0

let cal = function
        | ['*';b2;'*';f2] -> ['*';add (2,b2);'*';add (1,f2)]
        | ['*';b2;f1;f2] ->  let f = count b2
                             ['*';add (1,b2);add ((1 + f),f1);add (1,f2)]
        | [b1;b2;'*';f2] ->  let b = List.sumBy count [b2;'*';f2] 
                             [add(b,b1);add(1,b2);'*';add(0,f2)]
        | [b1;b2;f1;f2] ->   let f = count b2
                             let s = List.sumBy count [b2;f2] 
                             [add(s,b1);add(0,b2);add(f,f1);add(0,f2)]

let rec output = function
       | (feedIn,[]) -> feedIn
       | (x10::x11::feedIn_tail, x00::x01:buffer_tail) ->  
                             let [b1;b2;f1;f2] = cal [x00;x01;x10;x11]
                             printf "%A" b1
                             f1::(output(f2::feedIn_tail,b2::buffer_tail))
       | ([f],[b]) -> printfn " "
                      [f]
       | _ -> printfn " "
              []

let rec MineField inputs (buffer:char list) = 
    match inputs with
       | head::tail -> 
                   let dumpRow=[for i in 0..buffer.Length -> '.']
                   match parseLine(head) with
                       |Controls(0,0) -> output(dumpRow,buffer) 
                       |Controls(r,c) -> output(dumpRow,buffer)
                                         printfn "Field"
                                         MineField tail []                     
                       |Mines(row) ->  let _buffer = output(row@['.'],buffer)
                                         MineField tail _buffer
        | [] -> buffer

MineField ["4 4";"*...";"....";".*..";"....";"3 5";"**...";".....";".*...";"0 0"] []