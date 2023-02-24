import time
import serial
import thread
import data as dt
dt.angle = ""
mesg = ""
ser_connect = 1
ser = serial.Serial('/dev/ttyACM1',115200)

print "Serial read"

def ser_getdata(_ser):
    while 1:
        _str = _ser.readline()
        dt.angle = _str

while True:
    if ser_connect == 1:
        thread.start_new_thread(ser_getdata,(ser,))
        ser_connect = 0
    print dt.angle


