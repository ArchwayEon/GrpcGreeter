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

        var greetReply1 = await client.GetGreetingAsync(
        new GreetRequest { Type = 1, Name = "Koi" });
            Console.WriteLine($"Greeting: {greetReply1.Message}");

            var greetReply2 = await client.GetGreetingAsync(
        new GreetRequest { Type = 2, Name = "Jeff" });
            Console.WriteLine($"Greeting: {greetReply2.Message}");

            var greetReply3 = await client.GetGreetingAsync(
        new GreetRequest { Type = 3, Name = "Emma" });
            Console.WriteLine($"Greeting: {greetReply3.Message}");


            Console.WriteLine("Press any key to exit...");
         Console.ReadKey();
      }
   }
}
