using System.Collections.Generic;

namespace IdentitySampleApi.BusinessLogicLayer.DTO
{
    public abstract class BaseResponseDTO
    {
        public List<string> Message { get; set; }
        public bool Status { get; set; }

        public BaseResponseDTO()
        {
            Message = new List<string>();
        }
    }
}
