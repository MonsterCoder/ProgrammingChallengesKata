inputs = [[1,10] ,[100 ,200], [201 ,210] ,[900 ,1000]]

p 'start ...'

def calCycle(n, lenght=0)
	lenght+=1;
	return lenght if n ==1;
	return calCycle(n /2,lenght) if (n % 2) == 0;
	calCycle(n*3+1,lenght)
end

inputs.each {|x| low, high = x; 
				lengths = (low..high).collect {|n| calCycle n}; 
				p "#{low} #{high} #{lengths.max}"}