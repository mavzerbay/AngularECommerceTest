using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Validators;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto customerBasketDto)
        {
            
            CustomerBasketDtoValidator validator = new CustomerBasketDtoValidator();
            ValidationResult validationResult = validator.Validate(customerBasketDto);

            if(!validationResult.IsValid){
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = validationResult.Errors.Select(x=>x.ErrorMessage) });
            }
            
            var basket = _mapper.Map<CustomerBasketDto,CustomerBasket>(customerBasketDto);
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}