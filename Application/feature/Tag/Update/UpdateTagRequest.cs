using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using MediatR;

namespace Application.feature.Tag.Update
{
    public class UpdateTagRequest : IRequest<object>
    {
        public TagModel TagModel { get; set; }
    }
}
