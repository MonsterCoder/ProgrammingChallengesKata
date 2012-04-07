open System
open System.Text.RegularExpressions

let inputs1 = ["3 4";"*...";"....";"....";"0 0"]
let inputs = ["4 4";"*...";"....";".*..";"....";"3 5";"**...";".....";".*...";"0 0"]

type Line =
    | Controls of int*int
    | Mines of char list

let parseLine line =
    if Regex.Match(line, @"^\d\s+\d$").Success then
         let [a;b]=[for r in Regex.Matches(line, @"\b\d+\b") ->r.Value |> Int32.Parse]
         Controls(a,b)
    else
         Mines([for c in line -> c])

let rec cal chars acc = 
   match chars with
        | [] -> ([], acc)
        | '*'::tail ->  let (c,r) = (acc + 1) |> cal tail 
                        ('*'::c, r)
        | '.'::tail ->  let (c,r) = acc |> cal tail 
                        (r.ToString().Chars(0)::c,r)    
        | i::tail ->    let (c,r) =  acc |> cal tail 
                        let s = ((Int32.Parse (i.ToString())) + r).ToString().Chars(0)
                        (s::c,acc)  
        | _ -> ([], acc)

let rec output = function
       | (feedIn,[]) -> feedIn
       | (feedIn_1::feedIn_2::feedIn_tail, buffer_1::buffer_2::buffer_tail) ->  
                             let ([x1;x2;y1;y2],_) = cal [feedIn_1;feedIn_2;buffer_1;buffer_2] 0
                             printf "%A" y1
                             let tail_result = output(x2::feedIn_tail,y2::buffer_tail)
                             x1::tail_result
       | _ -> []

let rec MineField inputs (buffer:char list) = 
    match inputs with
       | head::tail -> 
                   match parseLine(head) with
                       |Controls(0,0) -> output([for i in 0..buffer.Length -> '.'],buffer)
                                         
                       |Controls(r,c) -> output([for i in 0..buffer.Length -> '.'],buffer)
                                         MineField tail []    
                                                               
                       |Mines(row) ->    let _buffer = output(row@['.'],buffer)
                                         MineField tail _buffer
        | [] -> buffer
                                         
MineField inputs1 []