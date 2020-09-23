using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter
{
    public class CustomMathService : CustomMath.CustomMathBase
    {
        private readonly ILogger<CustomMathService> _logger;
        public CustomMathService(ILogger<CustomMathService> logger)
        {
            _logger = logger;
        }

        public override Task<AddReply> Add(AddRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddReply
            {
                Result = request.Num1 + request.Num2
            }); ; ;
        }

        public override Task<SineReply> Sine(SineRequest request, ServerCallContext context)
        {

            return Task.FromResult(new SineReply
            {
                Result = Math.Sin(request.Num1)
            }); ; ;
        }
    }
}
