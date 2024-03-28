using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductContoller : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        public ProductContoller(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository CustomerWriteRepository,
            ICustomerReadRepository customerReadRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerWriteRepository = CustomerWriteRepository;
            _customerReadRepository = customerReadRepository;
           
        }

        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("169b0747-685b-45eb-afdf-46e7baebb942");
            order.Address = "Edirne";
            await _orderWriteRepository.SaveAsync();

            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Sefa" });

            //await _orderWriteRepository.AddAsync(new() { Address = "Antalya", Description = "asadafasada", CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync();

            //Customer customer = await _customerReadRepository.GetByIdAsync("3a4873fc-b3a6-4fcb-8e0d-ff83fdcc4573");
            //customer.Name = "sadsad";
            //await _customerWriteRepository.SaveAsync();


        }


    }
}
