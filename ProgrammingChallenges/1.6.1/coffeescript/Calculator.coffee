Calculate = do->
	count=0

	_calculate = (n)->
		n=parseInt(n)
		count+=1
		#console.log n
		if n is 1
			count
		else if n % 2 is 0
			_calculate(n / 2)
		else
			_calculate((n*3)+1)
			
	_calculate
	
module.exports= Calculate