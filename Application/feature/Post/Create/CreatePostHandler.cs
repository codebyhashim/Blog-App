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

namespace Application.feature.Post.Create
{
    public class CreatePostHandler : IRequestHandler<CreatePostRequest, object>
    {
        private readonly IGenericRepository<BlogModel> _genericRepository;
        private readonly ILogger<CreatePostHandler> _logger;

        public CreatePostHandler(IGenericRepository<BlogModel> genericRepository, ILogger<CreatePostHandler> logger)
        {
            this._genericRepository = genericRepository;
            this._logger = logger;
        }

        public async Task<object> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {

                return ErrorResult.Failure(CustomStatusKey.validationError, CustomStatusCodes.InternalServerError);

            }
           
            var postObj = await _genericRepository.AddAsync( "blog_create", request.Model);

            if (!postObj)
            {
                _logger.LogError("record are not createee");

                return ErrorResult.Failure(CustomStatusKey.InternalServerError, CustomStatusCodes.InternalServerError);

            }
            return new
            {
                Reponse = postObj,
                message = "successfully created"
            };
        }
    }
}
