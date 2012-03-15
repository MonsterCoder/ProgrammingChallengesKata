inputs = ["4 4","*...","....",".*..","....","3 5","**...",".....",".*...","0 0"]
fileds =[]

console.log "start ..."
idx =-1

class Mfield
		constructor: (@rowcount, @columncount)->
          @rows=[]
        addRow: (row)-> @rows.push ((if (row[i] is '*') then 1 else 0) for i in [0...@columncount])
		output: (idx)-> 
                      console.log "Field#{idx}"
                      for r in [0...@rowcount]
                           line=[]
                           for c in [0...@columncount]  
                              n= (@rows[r-1]?[c-1] ? 0)+(@rows[r-1]?[c] ? 0)+(@rows[r-1]?[c+1] ? 0)+(@rows[r]?[c-1] ? 0)+(@rows[r]?[c] ? 0)+(@rows[r]?[c+1] ? 0)+(@rows[r+1]?[c-1] ? 0)+(@rows[r+1]?[c] ? 0)+(@rows[r+1]?[c+1] ? 0)
                              line.push  n
                           console.log line
                          
                          
readinputs = (arr) -> 
         [head, tail...] = arr
         
         if /0\s+0/.test head
              return 
         else if /^\d\s+\d$/.test head
              [r, c] = head.match(/\d/mg)
              fileds[++idx]=new Mfield(r, c)
         else
              fileds[idx].addRow(head)

           
         readinputs tail unless tail.length is 0

readinputs inputs

i =1

field.output(i++) for field in fileds
