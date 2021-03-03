using API.Dtos;
using FluentValidation;

namespace API.Validators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(m=>m.DisplayName).NotEmpty().WithMessage("Görünen isim alanı zorunludur.");
            RuleFor(m=>m.Email).NotEmpty().WithMessage("E-posta alanı zorunludur.").EmailAddress().WithMessage("Geçersiz e-posta!");
            RuleFor(m=>m.Password).NotEmpty().WithMessage("Şifre alanı zorunludur.").Matches("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$").WithMessage("Şifreniz en az 1 büyük, 1 küçük, 1 sayı, 1 alfanümerik olmayan karakter içermeli ve en az 6 karakterli olmalıdır!");
        }
    }
}