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

namespace Application.feature.Post.Delete
{
    public class DeletePostHandler : IRequestHandler<DeletePostRequest, object>
    {
        private readonly IGenericRepository<BlogModel> _genericRepository;
        private readonly ILogger<DeletePostHandler> _logger;

        public DeletePostHandler(IGenericRepository<BlogModel> genericRepository, ILogger<DeletePostHandler> logger)
        {
            this._genericRepository = genericRepository;
            this._logger = logger;
        }

        public async Task<object> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorResult.Failure(CustomStatusKey.validationError,CustomStatusCodes.NotFound);
            }
            var response= await _genericRepository.DeleteAsync(request.Id, "delete_blog");
            if (!response)
            {
                _logger.LogError("error occur while delete the post controller : BlogPost action : Delete");
                return ErrorResult.Failure(CustomStatusKey.InternalServerError, CustomStatusCodes.InternalServerError);
            }
            return new
            {
                Reponse=response,
                message="successfully deleted"
            };
        }
    }
}
