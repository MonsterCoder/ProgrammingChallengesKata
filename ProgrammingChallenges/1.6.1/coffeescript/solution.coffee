inputs = require('./inputs')

cycle = (n, length=0)->
	length +=1
	if n is 1
		length
	else if n % 2 is 0
		cycle(n / 2, length)
	else
		cycle((n*3)+1, length)

console.log("Start...")	

for x, y of inputs
	q = (cycle(num) for num in [x..y]).reduce (a,b) -> Math.max a , b
	console.log("#{x} #{y} #{q}")

		
	