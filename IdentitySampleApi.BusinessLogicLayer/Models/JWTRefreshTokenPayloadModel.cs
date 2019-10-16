namespace IdentitySampleApi.BusinessLogicLayer.Models
{
    public class JWTRefreshTokenPayloadModel
    {
        public string UniqueId { get; set; }
        public string AccessToken { get; set; }
    }
}
