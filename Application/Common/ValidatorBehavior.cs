using FluentValidation;
using MediatR;

namespace Application.Common
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));

                var faliureMessage = validationResult.SelectMany(f => f.Errors).
                    Where(error => error != null).ToList();

                if (faliureMessage.Count !=0)
                {
                    throw new ValidationErrorHandler<TResponse>(string.Join("",faliureMessage));
                }
            }
            return await next();
        }
    }
}
