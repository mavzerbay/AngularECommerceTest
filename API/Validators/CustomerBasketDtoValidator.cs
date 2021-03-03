using API.Dtos;
using FluentValidation;

namespace API.Validators
{
    public class CustomerBasketDtoValidator:AbstractValidator<CustomerBasketDto>
    {
        public CustomerBasketDtoValidator()
        {
            RuleFor(m=>m.Id).NotEmpty();
            RuleForEach(m=>m.Items).SetValidator(new BasketItemDtoValidator());
        }
    }
}