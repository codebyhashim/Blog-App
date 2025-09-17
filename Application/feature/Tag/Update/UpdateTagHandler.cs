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

        public async Task<object> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            var tag = await _repository.UpdateAsync(request.TagModel, "Tag_Update",request.TagModel.Id);
            if (!tag) {
                _logger.LogError("record are not updated");
                return ErrorResult.Failure(CustomStatusKey.validationError, CustomStatusCodes.InternalServerError); }
            return new { message = "successfully updated", response = tag };
        }
    }
}
