using System.Net;
using System.Net.Sockets;

namespace server;

class Program
{
    static void Main(string[] args)
    {
        SockExercise2.Server();
    }
}


public class SockExercise1 
{
    // 1. Bygg en enkelt print-server. Starta upp en server-socket som väntar på inkommande meddelanden. Allt servern gör när någon ansluter är att printa ut det första meddelandet den får och sedan så avslutas anslutningen.

    // Använd webbläsaren för att testa servern. Webbläsaren använder HTTP vilket använder TCP så det är ett bra sätt att testa på.
    public static void Server() 
    {
        IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 25500);

        Socket serverSocket = new Socket(
            ipAddress.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp
        );

        serverSocket.Bind(ipEndPoint);
        serverSocket.Listen();

        Socket client = serverSocket.Accept();
        Console.WriteLine("A client has connected!");
        
        byte[] incoming = new byte[10000];
        int read = client.Receive(incoming);
        string response = System.Text.Encoding.UTF8.GetString(incoming, 0, read);
        Console.WriteLine(response);
    }
}

//övning 3 också
public class SockExercise2 
{

    public static void Server() 
    {
        IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 25500);

        Socket serverSocket = new Socket(
            ipAddress.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp
        );

        serverSocket.Bind(ipEndPoint);
        serverSocket.Listen();

        Socket client = serverSocket.Accept();
        Console.WriteLine("A client has connected!");
        
        while(true) 
        {       

            byte[] incoming = new byte[10000];
            int read = client.Receive(incoming);

            client.Send(incoming);
        }
        
    }
}