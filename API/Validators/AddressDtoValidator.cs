using API.Dtos;
using FluentValidation;

namespace API.Validators
{
    public class AddressDtoValidator:AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(m=>m.FirstName).NotEmpty().WithMessage("Adı alanı zorunludur.");
            RuleFor(m=>m.LastName).NotEmpty().WithMessage("Soyadı alanı zorunludur.");
            RuleFor(m=>m.Street).NotEmpty().WithMessage("Sokak alanı zorunludur.");
            RuleFor(m=>m.City).NotEmpty().WithMessage("Şehir alanı zorunludur.");
            RuleFor(m=>m.State).NotEmpty().WithMessage("Mahalle alanı zorunludur.");
            RuleFor(m=>m.Zipcode).NotEmpty().WithMessage("Posta kodu alanı zorunludur.");
        }
    }
}