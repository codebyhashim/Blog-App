using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.feature.Tag.GetById
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdRequest, object>
    {
        public GetTagByIdHandler()
        {
        }

        public Task<object> Handle(GetTagByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
