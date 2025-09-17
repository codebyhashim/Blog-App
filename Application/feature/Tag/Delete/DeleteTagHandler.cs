using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.model.ResponseWrapper;
using Application.Repositories;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using static Domain.Constants.BlogConstants;

namespace Application.feature.Tag.Delete
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagRequest, object>
    {
        private readonly ILogger<DeleteTagHandler> _logger;
        private readonly IGenericRepository<TagModel> _repository;

        public DeleteTagHandler(ILogger<DeleteTagHandler> logger, IGenericRepository<TagModel> repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public async Task<object> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
        {
            var tag = await _repository.DeleteAsync(request.TagId,"Tag_Delete");
            if (!tag) {
                _logger.LogError("record are not deleted");
                return ErrorResult.Failure(CustomStatusKey.validationError, CustomStatusCodes.InternalServerError);
            }
            return new { message = "successfully deleted", response = tag };
        }
    }
}
