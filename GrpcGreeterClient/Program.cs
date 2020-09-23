using Grpc.Net.Client;
using GrpcGreeter;
using System;
using System.Threading.Tasks;

namespace GrpcGreeterClient {
	class Program {
		static async Task Main(string[] args) {
			using var channel = GrpcChannel.ForAddress("https://localhost:5001");
			var client = new Greeter.GreeterClient(channel);
			var client2 = new CustomMath.CustomMathClient(channel);

			var reply = await client.GetGreetingAsync(
				 new GreetRequest { Type = 1, Name = "Jathan" });
			Console.WriteLine($"Response: {reply.Message}");

			reply = await client.GetGreetingAsync(
						new GreetRequest { Type = 2, Name = "Jathan" });
			Console.WriteLine($"Response: {reply.Message}");

			reply = await client.GetGreetingAsync(
						new GreetRequest { Type = 3, Name = "Jathan" });
			Console.WriteLine($"Response: {reply.Message}");

			var addReply = await client2.AddAsync(
						new AddRequest { Num1 = 123, Num2 = 234 });
			Console.WriteLine($"123 + 234 = {addReply.Answer}");

			var sineReply = await client2.SineAsync(
						new SineRequest { Num1 = 0 });
			Console.WriteLine($"Sine(0) = {sineReply.Answer}");

			sineReply = await client2.SineAsync(
						new SineRequest { Num1 = 10 });
			Console.WriteLine($"Sine(10) = {sineReply.Answer}");

			sineReply = await client2.SineAsync(
						new SineRequest { Num1 = 30 });
			Console.WriteLine($"Sine(30) = {sineReply.Answer}");

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
