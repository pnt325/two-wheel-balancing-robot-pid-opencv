import socket
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print "Waiting For Client..."
host = socket.gethostname()
server.bind(('192.168.1.4',9999))
server.listen(1)

while True:
    conn, client = server.accept()
    try:
        print "Ket noi tu: ", client

        data = conn.recv(1024)
        print "Client: ", data
    except:
        break
