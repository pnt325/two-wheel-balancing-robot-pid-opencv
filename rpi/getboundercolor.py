# import the necessary packages
from imutils.video import VideoStream
import numpy as np
import argparse
import imutils
import time
import cv2
import socket

vs = VideoStream(usePiCamera=1).start()
time.sleep(2.0)


def cross_line(image,dx,dy):
        cv2.line(image,(0,dy/2),(dx,dy/2),(0,255,0),1)
        cv2.line(image,(dx/2,0),(dx/2,dy),(0,255,0),1)
def track_bar():
        pass
background = np.zeros((255,255,255), np.uint8)
cv2.namedWindow('background')
cv2.createTrackbar('L_H','background',0,179,track_bar)
cv2.createTrackbar('U_H','background',0,179,track_bar)
cv2.createTrackbar('L_S','background',0,255,track_bar)
cv2.createTrackbar('U_S','background',0,255,track_bar)
cv2.createTrackbar('L_V','background',0,255,track_bar)
cv2.createTrackbar('U_V','background',0,255,track_bar)
             
while True:
	frame = vs.read()
	frame = imutils.resize(frame, width=400)
	frame = cv2.flip(frame,1)
                
        lh = cv2.getTrackbarPos('L_H','background')
        ls = cv2.getTrackbarPos('L_S','background')
        lv = cv2.getTrackbarPos('L_V','background')

        uh = cv2.getTrackbarPos('U_H','background')
        us = cv2.getTrackbarPos('U_S','background')
        uv = cv2.getTrackbarPos('U_V','background')

        
        Lower = (lh,ls,lv)
        Upper = (uh,us,uv)

	#conver to hsv color
	hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

        mask = cv2.inRange(hsv,Lower, Upper)
        mask = cv2.erode(mask, None, iterations = 2)
        mask = cv2.dilate(mask, None, iterations = 2)

        cross_line(frame,400,300)
        
	cv2.imshow("Frame", frame)
	cv2.imshow("Mask", mask)
	key = cv2.waitKey(1) & 0xFF
        
	if key == ord("s"):
                cv2.imwrite('img.png', frame)
                print 'img.png saved!'
	if key == ord("q"):
		break
 
# do a bit of cleanup
cv2.destroyAllWindows()
vs.stop()
