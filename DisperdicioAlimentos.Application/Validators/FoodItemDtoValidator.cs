using FluentValidation;
using DisperdicioAlimentos.Application.DTOs;
using System;

namespace DisperdicioAlimentos.Application.Validators
{
    public class FoodItemDtoValidator : AbstractValidator<FoodItemDto>
    {
        public FoodItemDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Food item name is required.")
                .MaximumLength(100).WithMessage("Food item name cannot exceed 100 characters.");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("Expiration date is required.")
                .GreaterThan(DateTime.UtcNow.Date).WithMessage("Expiration date must be in the future.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(100).WithMessage("Location cannot exceed 100 characters.");
        }
    }
}
