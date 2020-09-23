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

        public override Task<AddResponse> Add(AddRequest request, ServerCallContext context)
        {
            double result = request.Number1 + request.Number2;
            return Task.FromResult(new AddResponse { Sum = result });
        }

        public override Task<SineResponse> Sine(SineRequest request, ServerCallContext context)
        {
            double result = Math.Sin(request.Number * Math.PI / 180.0);

            return Task.FromResult(new SineResponse { Value = result });
        }
    }
}
