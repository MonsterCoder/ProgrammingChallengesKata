cal = require('./Calculator')

pairs = 
	1 : 10
	100 : 200
	201 : 210
	900 : 1000

console.log("Start...")	
#console.log cal(22)

for min, max of pairs
	seq = (cal(num) for num in [min..max])
	#console.log(seq.reduce (a,b) -> Math.max a, b)
	m = 0 #reset m
	m = Math.max(m, num) for num in seq
	console.log("#{min} #{max} #{m}")

		
	