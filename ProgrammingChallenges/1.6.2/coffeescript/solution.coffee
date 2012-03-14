inputs = ["4 4","*...","....",".*..","....","3 5","**...",".....",".*...","0 0"]
fileds =[]

console.log "start ..."
idx =0

class Mfield
		constructor: (@rowcount, @columncount)->
          @rows=[];
        addRow: (row)->@rows.push row
			
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
console.log fileds

