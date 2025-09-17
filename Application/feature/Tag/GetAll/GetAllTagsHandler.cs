using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.feature.Tag.Create;
using Application.feature.Tag.Delete;
using Application.Repositories;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.feature.Tag.GetAll
{
    public class GetAllTagsHandler : IRequestHandler<CreateTagRequest, object>
    {
        private readonly ILogger<DeleteTagHandler> _logger;
        private readonly IGenericRepository<TagModel> _repository;
        public GetAllTagsHandler(ILogger<DeleteTagHandler> logger, IGenericRepository<TagModel> repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public Task<object> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
