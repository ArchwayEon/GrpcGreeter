using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter {
	public class CustomMathService : CustomMath.CustomMathBase {
		private readonly ILogger<GreeterService> _logger;
		public CustomMathService(ILogger<GreeterService> logger) {
			_logger = logger;
		}

		public override Task<AddReply> Add(AddRequest request, ServerCallContext context) {
			return Task.FromResult(new AddReply {
				Answer = (double)(request.Num1 + request.Num2)
			});
		}

		public override Task<SineReplay> Sine(SineRequest request, ServerCallContext context) {
			return Task.FromResult(new SineReplay {
				Answer = Math.Sin((Math.PI / 180.0) * request.Num1)
			});
		}
	}
}
