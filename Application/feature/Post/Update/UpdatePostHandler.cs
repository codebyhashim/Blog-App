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

namespace Application.feature.Post.Update
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostRequest, object>
    {
        private readonly ILogger<UpdatePostHandler> _logger;
        private readonly IGenericRepository<BlogModel> _genericRepository;

        public UpdatePostHandler(ILogger<UpdatePostHandler> logger, IGenericRepository<BlogModel> genericRepository)
        {
            this._logger = logger;
            this._genericRepository = genericRepository;
        }

        public async Task<object> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
                var blogModel = new BlogModel
                {
                    BlogPostId = request.Model.BlogPostId,
                    Title = request.Model.Title,
                    Content = request.Model.Content,
                    CategoryId = request.Model.CategoryId,
                    ImageUrl = request.Model.ImageUrl,
                    Status = Domain.Model.PostStatus.Draft,
                    UserId = request.Model.UserId

                };
                var post = await _genericRepository.UpdateAsync(blogModel, "updateBlog", request.Model.BlogPostId);
                if (!post)
                {
                    _logger.LogError("ControllerName: blogpost ActionName : UpdatePost message: ERROR occure while updating post");
                    return ErrorResult.Failure(CustomStatusKey.InternalServerError, CustomStatusCodes.InternalServerError);
                }
            return new { response = post, message = "message : post  successfully updated : " };

       
        }
    }
}
