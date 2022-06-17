using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBeer
{
    public class CreateBeerCommandValidator : AbstractValidator<CreateBeerCommand>
    {
        public CreateBeerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Beer Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Beer Name} must not exceed 50 characters.");

            RuleFor(p => p.BreweryId)
                .NotNull().WithMessage("{Brewery Id } is required.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("{Price } is required.");


            RuleFor(p => p.SellingPrice)
                .NotNull().WithMessage("{Selling Price } is required.");


        }
    }
}