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
                new GreetRequest { Type = 1, Name = "GreeterClient" });
            Console.WriteLine($"Greeting: {greeting.Message}");
            greeting = await client.GetGreetingAsync(
                            new GreetRequest { Type = 2, Name = "GreeterClient" });
            Console.WriteLine($"Greeting: {greeting.Message}");
            greeting = await client.GetGreetingAsync(
                            new GreetRequest { Type = 3, Name = "GreeterClient" });
            Console.WriteLine($"Greeting: {greeting.Message}");

            var client2 = new CustomMath.CustomMathClient(channel);
            var sum = await client2.AddAsync(new AddRequest { Value1 = 2, Value2 = 5});
            var sine1 = await client2.SineAsync(new SineRequest { Value = 0 });
            var sine2 = await client2.SineAsync(new SineRequest { Value = 10 });
            var sine3 = await client2.SineAsync(new SineRequest { Value = 30 });

            Console.WriteLine($"2 + 5 = {sum.Sum}");
            Console.WriteLine($"sin(0) = {sine1.Value}");
            Console.WriteLine($"sin(10) = {sine2.Value}");
            Console.WriteLine($"sin(30) = {sine3.Value}");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
