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

namespace Application.feature.Tag.Create
{
    public class CreateTagHandler : IRequestHandler<CreateTagRequest, object>
    {
        private readonly IGenericRepository<TagModel> _repository;

        public CreateTagHandler(ILogger<CreateTagHandler> logger, IGenericRepository<TagModel> repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            var tag =await _repository.AddAsync("Tag_Create",request.Model);
            if (!tag)
            {
                return ErrorResult.Failure(CustomStatusKey.InternalServerError, CustomStatusCodes.InternalServerError);
            }
            return new {message = "tag succesfully created",response = tag};
        }
    }
}
