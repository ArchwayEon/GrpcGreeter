using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter {
	public class GreeterService : Greeter.GreeterBase {
		private readonly ILogger<GreeterService> _logger;
		public GreeterService(ILogger<GreeterService> logger) {
			_logger = logger;
		}

		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context) {
			return Task.FromResult(new HelloReply {
				Message = "Hello " + request.Name
			});
		}

		public override Task<GreetReply> GetGreeting(GreetRequest request, ServerCallContext context) {
			var message = "";

			switch (request.Type) {
				case 1:
					message = "Hi " + request.Name;
					break;

				case 2:
					message = "Howdy " + request.Name;
					break;

				case 3:
					message = "Bye " + request.Name;
					break;
			}

			return Task.FromResult(new GreetReply {
				Message = message
			});
		}
	}
}
