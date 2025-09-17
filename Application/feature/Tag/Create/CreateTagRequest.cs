using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.model.Dto;
using Domain.Model;
using MediatR;

namespace Application.feature.Tag.Create
{
    public class CreateTagRequest : IRequest<object>
    {
        public CreateTagDto Model { get; set; }
    }
}
