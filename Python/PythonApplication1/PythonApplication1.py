
import os
import io

def test1():
	print(os.path)
	print ('Hello World')
	x = open("c:\Temp\TestFile.txt",r)
	lines = x.readlines
	for l in lines:
		print(l)

		




