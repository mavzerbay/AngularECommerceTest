using API.Dtos;
using FluentValidation;

namespace API.Validators
{
    public class BasketItemDtoValidator : AbstractValidator<BasketItemDto>
    {
        public BasketItemDtoValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.ProductName).NotEmpty().WithMessage("Ürün adı alanı zorunludur.");
            RuleFor(m => m.Price).NotEmpty().WithMessage(m=>m.ProductName!=null? m.ProductName +" isimli ürünün fiyat alanı zorunludur." :"Fiyat alanı zorunludur.").GreaterThan(0).WithMessage(m=>m.ProductName!=null? m.ProductName +" isimli ürünün fiyatı ₺ 0 olamaz !":"Fiyat ₺ 0 olamaz !");
            RuleFor(m => m.Quantity).NotEmpty().WithMessage(m=>m.ProductName!=null? m.ProductName +" isimli ürünün miktar alanı zorunludur.":"Miktar alanı zorunludur.").GreaterThan(0).WithMessage(m=>m.ProductName!=null? m.ProductName +" isimli ürünün miktarı 1'den az olamaz !":"Miktar 1'den az olamaz !");
            RuleFor(m => m.PictureUrl).NotEmpty().WithMessage("Ürün resmi alanı zorunludur.");
            RuleFor(m => m.Brand).NotEmpty().WithMessage("Marka alanı zorunludur.");
            RuleFor(m => m.Type).NotEmpty().WithMessage("Tür alanı zorunludur.");
        }
    }
}