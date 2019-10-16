using System.Collections.Generic;

namespace IdentitySampleApi.BusinessLogicLayer.DTO.Account
{
    public abstract class BaseAccountResponseDTO
    {
        public List<string> Message { get; set; }
        public bool Status { get; set; }

        public BaseAccountResponseDTO()
        {
            Message = new List<string>();
        }
    }
}
