using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBrewery
{
    public class CreateBreweryCommandValidator : AbstractValidator<CreateBreweryCommand>
    {
        public CreateBreweryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Brewery Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Brewery Name} must not exceed 50 characters.");

        }
    }
}