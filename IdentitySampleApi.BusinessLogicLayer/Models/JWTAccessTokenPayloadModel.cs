using System;
using System.Collections.Generic;

namespace IdentitySampleApi.BusinessLogicLayer.Models
{
    public class JWTAccessTokenPayloadModel
    {
        //Jti
        public string UniqueId { get; set; }
        //NameIdentifier
        public string UserId { get; set; }
        //Sub
        public string UserName { get; set; }
        //Role
        public IList<string> UserRoles { get; set; }
    }
}
