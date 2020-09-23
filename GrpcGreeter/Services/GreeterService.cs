using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<GreetReply> GetGreeting(GreetRequest request, ServerCallContext context)
        {
            string greeting = String.Empty;
            switch(request.Type)
            {
                case 1:
                    greeting = "Hi " + request.Name;
                    break;
                case 2:
                    greeting = "Howdy " + request.Name;
                    break;
                case 3:
                    greeting = "Bye " + request.Name;
                    break;
            }

            return Task.FromResult(new GreetReply
            {
                //note = greeting
            });
        }
}
}
