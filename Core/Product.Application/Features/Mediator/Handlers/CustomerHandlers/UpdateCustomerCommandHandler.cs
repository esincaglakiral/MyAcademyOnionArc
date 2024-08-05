using AutoMapper;
using MediatR;
using Product.Application.Features.CQRS.Commands.CategoryCommands;
using Product.Application.Features.Mediator.Commands.CustomerCommands;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            await _customerRepository.UpdateAsync(customer);
        } 
    }
}
