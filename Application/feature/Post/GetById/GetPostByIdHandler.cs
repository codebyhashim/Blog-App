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

namespace Application.feature.Post.GetById
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequest, object>
    {
        private readonly IGenericRepository<BlogModel> _genericRepository;
        private readonly ILogger<GetPostByIdHandler> _logger;

        public GetPostByIdHandler(IGenericRepository<BlogModel> genericRepository, ILogger<GetPostByIdHandler> logger)
        {
            _genericRepository = genericRepository;
            _logger = logger;
        }

        public async Task<object> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            if (request==null)
            {

                return ErrorResult.Failure(CustomStatusKey.validationError, CustomStatusCodes.InternalServerError);

            }
            var postObj = await _genericRepository.GetByIdAsync(request.Id, "getPostById");

            if (postObj == null)
            {
                _logger.LogError("record are not exist");

                return ErrorResult.Failure(CustomStatusKey.NotExist, CustomStatusCodes.NotFound);

            }
            return postObj;
        }
    }
}
