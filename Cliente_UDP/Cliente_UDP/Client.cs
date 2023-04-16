using System.Net;
using System.Net.Sockets;
using System.Text;


class Client 
{
        static void Main(string[] args)
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress broadcast = IPAddress.Parse("192.168.3.15");
        Console.WriteLine("Digite um número inteiro...");
        var message = Console.ReadLine();
        int sqr = int.Parse(message);

        while (message != string.Empty)
        {
            byte[] sendbuf = Encoding.ASCII.GetBytes(message);
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

            s.SendTo(sendbuf, ep);

            Console.WriteLine("Mensagem enviada ao endereço");

            message = Console.ReadLine();
        }
        Console.ReadLine();
    }
}
