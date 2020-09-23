using Grpc.Net.Client;
using GrpcGreeter;
using System;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
               new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine($"Greeting: {reply.Message}");

            var greeting = await client.GetGreetingAsync(
                new GreetRequest { Name = "Greet Request Client", Type = 1}
                );
            Console.WriteLine($"Response: {greeting}");

            var client2 = new CustomMath.CustomMathClient(channel);
            var sum = await client2.AddAsync(new AddRequest { Number1 = 40f, Number2 = 2f });
            var sine1 = await client2.SineAsync(new SineRequest { Number = 0 });
            var sine2 = await client2.SineAsync(new SineRequest { Number = 10 });
            var sine3 = await client2.SineAsync(new SineRequest { Number = 30 });

            Console.WriteLine($"Sum: {sum.Sum}");
            Console.WriteLine($"Sine: {sine1.Value}");
            Console.WriteLine($"Sine: {sine2.Value}");
            Console.WriteLine($"Sine: {sine3.Value}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
