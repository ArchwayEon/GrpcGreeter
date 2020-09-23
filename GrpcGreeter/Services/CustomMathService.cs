using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcGreeter.Services
{
    public class CustomMathService: CustomMath.CustomMathBase
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
                Sum = request.Value1 + request.Value2
            });
        }

        public override Task<SineReply> Sine(SineRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SineReply
            {
                Value = Math.Sin(request.Value * Math.PI / 180.0)
            });
        }
    }
}
