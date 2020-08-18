using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.Common.Behaviours
{
    /// <summary>
    /// The pipeline behaviour for the validation.
    /// </summary>
    /// <typeparam name="TRequest">Type of <see cref="IRequest"/></typeparam>
    /// <typeparam name="TResponse">Type of <see cref="IRequest{TResponse}"</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validators"></param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(results => results.Errors).Where(failuers => failuers != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
