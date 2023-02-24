import socket
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect((socket.gethostname(), 8080))
while True:
    try:
        mesg = "Hello server"
        client.sendall(mesg.encode('ascii'))

        amount_received = 0
        amount_expected = len(mesg)
        while amount_received < amount_expected:
            data = client.recv(1024)
            amount_received += len(data)
            print "Server: ", data
    except:
        pass
