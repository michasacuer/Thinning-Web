namespace Thinning.Web.Filters.Validator.Test
{
    using FluentValidation;
    using Thinning.Application.Test.Command.AcceptTest;
    
    public class AcceptTestValidator : AbstractValidator<AcceptTestCommand>
    {
        public AcceptTestValidator()
        {
            RuleFor(x => x.Guid).NotEmpty();
            RuleFor(x => x.Accepted).NotEmpty();
        }
    }
}
