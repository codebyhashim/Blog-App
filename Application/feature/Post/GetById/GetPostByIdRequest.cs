using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.model.Dto;
using Domain.Model;
using MediatR;

namespace Application.feature.Post.GetById
{
    public class GetPostByIdRequest : IRequest<object>
    {
        

        public int Id { get; set; }
    }
}
