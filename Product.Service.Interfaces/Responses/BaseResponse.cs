using Product.Service.Interfaces.Responses;
using System.Collections.Generic;

namespace Product.Service.Interfaces
{
    public abstract class BaseResponse
    {
        public List<Error> Errors { get; set; }
    }
}
