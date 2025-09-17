using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.feature.Tag.Create
{
    public class CreateTagHandler : IRequestHandler<CreateTagRequest, object>
    {
        private readonly IGenericRepository<TagModel> _repository;

        public CreateTagHandler(ILogger<CreateTagHandler> logger, IGenericRepository<TagModel> repository)
        {
            _repository = repository;
        }

        public Task<object> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
