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

namespace Application.feature.Tag.GetById
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdRequest, object>
    {
        private readonly ILogger<GetTagByIdHandler> _logger;
        private readonly IGenericRepository<TagModel> _repository;

        public GetTagByIdHandler(ILogger<GetTagByIdHandler> logger, IGenericRepository<TagModel> repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public async Task<object> Handle(GetTagByIdRequest request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.Id, "Tag_GetById");
            if (tag==null) 
            {
                _logger.LogError("record are not exist");
                return ErrorResult.Failure(CustomStatusKey.validationError, CustomStatusCodes.InternalServerError);
                    }
            return new { message = "successfully get", response = tag };
        }
    }
}
