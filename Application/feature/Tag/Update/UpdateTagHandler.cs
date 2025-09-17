using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.feature.Tag.Update
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagRequest, object>
    {
        private readonly ILogger<UpdateTagHandler> _logger;
        private readonly IGenericRepository<TagModel> _repository;

        public UpdateTagHandler(ILogger<UpdateTagHandler> logger, IGenericRepository<TagModel> repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public Task<object> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
