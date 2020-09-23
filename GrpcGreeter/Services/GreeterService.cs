using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
            var returnString = string.Empty;
            switch (request.Type)
            {
                case 1:
                    returnString = "Hi " + request.Name;
                    break;
                case 2:
                    returnString = "Howdy " + request.Name;
                    break;
                case 3:
                    returnString = "Bye " + request.Name;
                    break;

            }
            return Task.FromResult(new GreetReply
            {
                Message = returnString
            }) ;
        }

    }
}
