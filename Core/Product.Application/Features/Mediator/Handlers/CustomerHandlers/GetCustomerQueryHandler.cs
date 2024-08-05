using AutoMapper;
using MediatR;
using Product.Application.Features.Mediator.Queries.CustomerQueries;
using Product.Application.Features.Mediator.Results.CustomerResults;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IList<GetCustomerQueryResults>>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<GetCustomerQueryResults>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAsync();

            return _mapper.Map<IList<GetCustomerQueryResults>>(values);
        }
    }
}
