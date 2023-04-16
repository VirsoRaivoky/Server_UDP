using System.Net;
using System.Net.Sockets;
using System.Text;

class Server 
{
    private const int port = 11000;

    private static void StartListener()
    {
        UdpClient listener = new UdpClient(port);
        IPEndPoint groupEp = new IPEndPoint(IPAddress.Any, port);

        try
        {
            while (true)
            {
                Console.WriteLine("Esperando resposta do cliente");
                byte[] bytes = listener.Receive(ref groupEp);
                
                Console.WriteLine($"Mensagem recebida de {groupEp} :");

                var message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                int num = int.Parse(message);
                Double Sqrt = Math.Sqrt(num);

                Console.WriteLine($"Aqui está a raiz quadrada do seu numero: {Sqrt}");

            }
        }
        catch 
        {
            Console.WriteLine("Houve um erro..");
        }
        finally
        {
            listener.Close();
        }
    }
    public static void Main()
    {
        StartListener();
    }
}
