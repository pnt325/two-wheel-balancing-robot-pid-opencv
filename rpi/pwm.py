import RPi.GPIO as GPIO
import time

servo = 12

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(servo, GPIO.OUT)

servo = GPIO.PWM(servo, 50)
servo.start(0)

while True:
    servo.ChangeDutyCycle((float(120*10)/180) + 2.0)
