using MediatR;
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
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
    {
        private readonly IRepository<Customer> _customerRepository;

        public RemoveCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteAsync(request.Id);
        }
    }
}
