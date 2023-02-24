from imutils.video import VideoStream
import RPi.GPIO as GPIO
import cf as value
import numpy as np
import imutils
import time
import cv2
import thread
import socket
import serial
import base64

value.detect = False
value.detect_old = False
value.connect = False
value.enable = False
value.ser_connect = 1
value.send_image = 1
value.angle = ""

forward = 12
back    = 16
left    = 20
right   = 21

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

GPIO.setup(forward, GPIO.OUT)
GPIO.setup(back   , GPIO.OUT)
GPIO.setup(left   , GPIO.OUT)
GPIO.setup(right  , GPIO.OUT)

GPIO.output(forward, GPIO.LOW)
GPIO.output(back   , GPIO.LOW)
GPIO.output(left   , GPIO.LOW)
GPIO.output(right  , GPIO.LOW)


server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

def ser_getdata(_ser):
    while 1:
        mesg = _ser.readline()
        print mesg

def ser_recv(_ser):
    while True:
        _str = _ser.readline()
        value.angle = _str
        if (value.connect == True and value.send_image == 0):
            client.send("angle@" + _str + "@")
        #end if
#end ser_recv(_ser):

def tien():
    GPIO.output(forward, GPIO.HIGH)
    GPIO.output(back, GPIO.LOW)
def lui():
    GPIO.output(forward, GPIO.LOW)
    GPIO.output(back, GPIO.HIGH)
def dung_tl():
    GPIO.output(forward, GPIO.LOW)
    GPIO.output(back, GPIO.LOW)
def trai():
    GPIO.output(right, GPIO.LOW)
    GPIO.output(left, GPIO.HIGH)
def phai():
    GPIO.output(right, GPIO.HIGH)
    GPIO.output(left, GPIO.LOW)
def dung_tp():
    GPIO.output(left, GPIO.LOW)
    GPIO.output(right, GPIO.LOW)

try:
    ser = serial.Serial('/dev/ttyS0',115200)#khoi tao serial
    value.serial = True
    print "Connected to ttyS0"
    #thread.start_new_thread(ser_getdata,(ser_,))
except:
    value.serial = False
    pass

#try:
#    ser0 = serial.Serial('/dev/ttyACM0',115200)
#    print "Connected to ttyACM0"
#    thread.start_new_thread(ser_recv,(ser0,))
#except:
#    try:
#        ser0 = serial.Serial('/dev/ttyACM1',115200)
#        print "Connected to ttyACM1"
#        thread.start_new_thread(ser_recv,(ser0,))
#    except:
#        print "Can not connect to ttyAMx"
        
host = socket.gethostname()
port = 8080
server.bind(('192.168.170.102', port))
server.listen(1)

global client

def getdata(socket_client, socket_addr):
    while 1:
        try:
            data = socket_client.recv(1024)
            if data:
                print "Client: ",data
                chuoi = data.split('@')
                if chuoi[0] == "ct":#chuoi lenh dieu khien
                    if chuoi[1] == "forward":
                        tien()
                    elif chuoi[1] == "back":
                        lui()
                    elif chuoi[1] == "gostop":
                        dung_tl()
                    elif chuoi[1] == "left":
                        trai()
                    elif chuoi[1] == "right":
                        phai()
                    elif chuoi[1] == "turnstop":
                        dung_tp()
                    socket_client.send("mesg@Robot-"+chuoi[1]+"->OK@")
                elif chuoi[0] == "dt":#dieu khien camera
                    if chuoi[1] == "detecton":
                        value.detect = True
                        ser.write("")
                        socket_client.send("mesg@Camera Detect ON ->OK@")
                    elif chuoi[1] == "detectoff":
                        value.detect = False
                        socket_client.send("mesg@Camera Detect OFF ->OK@")
                elif chuoi[0] == "setgo":#cai dat
                    ser.write("st@fr" + chuoi[1])
                    #ser.write(chuoi[1])
                    ser.write("\n")
                    socket_client.send("mesg@Robot FR Speed set "+chuoi[1]+"->OK@")
                elif chuoi[0] == "setturn":#cai dat
                    ser.write("st@tr" + chuoi[1])
                    #ser.write(chuoi[1])
                    ser.write("\n")
                    socket_client.send("mesg@Robot TR Speed set "+chuoi[1]+"->OK@")
                elif chuoi[0] == "setenable":#Tat/mo robot
                    ser.write("st@en"+ chuoi[1]+"\n")
                    socket_client.send("mesg@Robot Enable "+chuoi[1]+"->OK@")

            else:
                socket_client.close()
                value.connect = False
                break
        except:
            socket_client.close()
            value.connect = False
            print "getdata::Client Disconnected"
            break

def send_image(socket_client,image):
        try:
            socket_client.send(image)
        except:
            print "Client close connect"
            valuse.connect = False
            socket_client.close()

capture = VideoStream(usePiCamera=1).start()
time.sleep(1)

#Bounder HSV Color ==========================#
Lower = (113,123,102)
Upper = (179,255,255)

#Lower = (117, 97, 71)
#Upper = (179,233,205)

bounder = 0
axis_x = 0
axis_y = 0
object_tracking = False

lr = 0
lr_old = 0
ud = 0
ud_old = 0

fb = 0
fb_old = 0

object_find = False
object_find_old = False
count = 0

auto_count = 0
control = 0
control_old = 0

while True:
    #Tao ket noi tcp giua may tinh voi raspberry
    if value.connect == False:
        try:
            cv2.destroyAllWindows()
            print "Wait for client connect"
            client_temp, addr = server.accept()
            print "Client ",addr, " connected"
            value.connect = True
            client = client_temp
            thread.start_new_thread(getdata,(client,addr))
        except:
            value.connect = False
            pass

    
    #Lay hinh anh tu pi camera va xu ly hinh anh
    frame = capture.read()
    frame = imutils.resize(frame, width = 400)
    frame = cv2.flip(frame,1)
    
    hsv_image = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
    mask = cv2.inRange(hsv_image, Lower, Upper)
    mask = cv2.erode(mask, None, iterations = 2)
    mask = cv2.dilate(mask, None, iterations = 2)
    hinh = frame
    #cv2.imshow("mask", mask)
    #cv2.imshow("hsv",hsv_image)
    #cv2.imshow("camera", hinh)
    
    cnts = cv2.findContours(mask.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)[-2]
    #Ve duong bao quang doi tuong duoc tim thay
    
    if len(cnts) > 0:
        auto_count = 0
        object_find = True
        c = max(cnts, key = cv2.contourArea)
        ((dx, dy), radius) = cv2.minEnclosingCircle(c)

        axis_x = int(dx - 200)
        axis_y = int(150 - dy)

        if radius > 5:
            object_tracking = True
            bounder = int(radius)
            #print "Buonder", bounder
        else:
            object_tracking = False
            
        if object_tracking == True:
            cv2.rectangle(frame,(int(dx-radius),int(dy-radius)),(int(dx+radius),int(dy+radius)),(255,255,255),1)
            cv2.line(frame,(0, int(dy)),(int(dx-radius),int(dy)),(255,255,255),1)
            cv2.line(frame,(int(dx+radius), int(dy)),(400,int(dy)),(255,255,255),1)

            cv2.line(frame,(int(dx), 0),(int(dx),int(dy-radius)),(255,255,255),1)
            cv2.line(frame,(int(dx), int(dy+radius)),(int(dx),300),(255,255,255),1)
                
        if value.detect == True and object_tracking == True:
            #####
            if axis_x < -20:
                trai()
            elif axis_x > 20:
                phai()
            else:
                dung_tp()
            #####################
            if axis_y < -20:
                ud = -1
            elif axis_y > 20:
                ud = 1
            else:
                ud = 0
            #######################
            if bounder < 40:
                tien()
            elif bounder > 60:
                lui()
            else:
                dung_tl()
            ###############Gui tinh hieu dieu khien servo
            control = 0
            ########
        else:
            if control == 0:
                dung_tp()
                dung_tl()
                ud = 0
            control = 1
    else:
        if value.detect == True:
            control = 0
            # dieu khien robot tu dong tim doi tuong
            if auto_count < 300:
                auto_count = auto_count + 1
                
            if auto_count == 10:
                ser.write("sv@au\n")
                dung_tp()
                dung_tl()
            if auto_count == 11:
                ser.write("st@fr40\n")
            if auto_count == 12:
                ser.write("st@tr15\n")
            if auto_count == 50:
                trai()
            if auto_count == 250:
                dung_tp()
            if auto_count == 280:
                phai()
            if auto_count == 480:
                dung_tp()
        else:
            if control == 0:
                dung_tp()
                dung_tl()
            control = 1

    #dieu khien servo bam theo doidst tuong    
    if(ud != ud_old):
        ud_old = ud
        if ud == 1:
            ser.write("sv@dw\n")
        elif ud == -1:
            ser.write("sv@up\n")
        elif ud == 0:
            ser.write("sv@sp\n")

    #Chuyen doi du lieu gui hinh anh len C#
    #cv2.imshow("frame",frame)
            
    #== Convert image to string
    encode_param = [cv2.IMWRITE_JPEG_QUALITY,40]
    result, imgencode = cv2.imencode('.jpg', frame, encode_param)
    data = np.array(imgencode)
    stringdata = data.tostring()

    #== Convert image to string
    #_str = base64.encodestring(frame)

    
    if value.connect == True and value.detect == True:
        client.send(stringdata)
        #client.send(_str)
        #thread.start_new_thread(send_image,(client,stringdata))

    key = cv2.waitKey(1) & 0xFF

    if key == ord('q'):
        break
#end while
cv2.destroyAllWindows()
