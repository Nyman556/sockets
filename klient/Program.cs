using System.Net;
using System.Net.Sockets;

namespace klient;

class Program
{
    static void Main(string[] args)
    {
        SockExercise2.Client();
    }
}

public class SockExercise1
{
    // 1. Bygg en enkelt print-server. Starta upp en server-socket som väntar på inkommande meddelanden. Allt servern gör när någon ansluter är att printa ut det första meddelandet den får och sedan så avslutas anslutningen.

    // Använd webbläsaren för att testa servern. Webbläsaren använder HTTP vilket använder TCP så det är ett bra sätt att testa på.
    public static void Client()
    {
        IPAddress ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 25500);

        Socket clientSocket = new Socket(
            ipAddress.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp
        );

        clientSocket.Connect(ipEndPoint);

        // Skicka meddelande till servern.
        string? msg = Console.ReadLine();

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);

        clientSocket.Send(buffer);
    }
}

public class SockExercise2
{
    public static void Client()
    {
        IPAddress ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 25500);

        Socket clientSocket = new Socket(
            ipAddress.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp
        );

        clientSocket.Connect(ipEndPoint);

        // Skicka meddelande till servern.
        string msg = "hejsan";

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);

        clientSocket.Send(buffer);

        do
        {
            byte[] incoming = new byte[10000];
            int read = clientSocket.Receive(incoming);
            string response = System.Text.Encoding.UTF8.GetString(incoming, 0, read);
            Console.WriteLine($"SERVERN SÄGER: {response}");

            msg = Console.ReadLine()!;
            buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(buffer);
        } while (msg != "exit");

    }
}
