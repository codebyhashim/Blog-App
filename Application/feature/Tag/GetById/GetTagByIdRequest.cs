using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.feature.Tag.GetById
{
    public class GetTagByIdRequest : IRequest<object>
    {
        public int Id { get; set; }
    }
}
