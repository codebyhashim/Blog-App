using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.feature.Tag.Delete
{
    public class DeleteTagRequest : IRequest<object>
    {
        public int Id { get; set; }
    }
}
