package peer

import (
	"bufio"
	"fmt"
	"net"
	"os"
)

/*var listener, err = net.Listen("tcp", ":"+port) es lo mismo que listener, err := net.Listen("tcp", ":"+port)
message, _ := reader.ReadString('\n') el guion bajo se utiliza para omitir alguna variable,
por ejemplo en ese caso reader.ReadString('\n')te regresa un string y un error y estoy omitiendo el error
err.Error() es parte de go y regresa el error como un string*/
var username string

func StartListening(port string, user string) {
	username = user
	listener, err := net.Listen("tcp", ":"+port)
	if err != nil {
		fmt.Println("Error listening:", err.Error())
		return
	}

	defer listener.Close()
	fmt.Printf("Peer is listening on port %v...\n", port)
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting connections:", err.Error())
			continue
		}

		go recieveMessage(conn)
		sendMessage(conn)
	}
}

func ConnectToPeer(address string, user string) {
	username = user
	conn, err := net.Dial("tcp", address)
	if err != nil {
		fmt.Println("Error connecting to peer", err.Error())
		return
	}
	defer conn.Close()

	go recieveMessage(conn)
	sendMessage(conn)
}

func recieveMessage(conn net.Conn) {
	defer conn.Close()
	reader := bufio.NewReader(conn)
	for {
		message, err := reader.ReadString('\n')
		if err != nil {
			fmt.Println("Error receiving message:", err.Error())
			return
		}
		fmt.Print(message)
	}
}

func sendMessage(conn net.Conn) {
	writer := bufio.NewWriter(conn)
	scanner := bufio.NewScanner(os.Stdin)
	fmt.Println("Connected to peer. Type your message:")
	for scanner.Scan() {
		message := scanner.Text()
		UserMessage := username + ": " + message + "\n"
		_, err := writer.WriteString(UserMessage)
		if err != nil {
			fmt.Println("Error sending message:", err.Error())
			return
		}
		writer.Flush()
	}
}
