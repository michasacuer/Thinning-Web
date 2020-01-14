namespace Thinning.Web.Filters.Validator.Test
{
    using FluentValidation;
    using Thinning.Application.Test.Command.AddTest;

    public class AddTestValidator : AbstractValidator<AddTestCommand>
    {
        public AddTestValidator()
        {
            RuleFor(x => x.Images).NotEmpty();
            RuleFor(x => x.PcInfo).NotEmpty();
            RuleFor(x => x.TestLines).NotEmpty();
        }
    }
}
