import time
import serial
import thread
global s
a = 10
ser = serial.Serial('/dev/ttyS0',115200)
while True:
    s = ser.readline()
    print s

