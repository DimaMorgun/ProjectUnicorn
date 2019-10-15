namespace IdentitySampleApi.BusinessLogicLayer.DTO
{
    public class BaseTokenResponseDTO : BaseResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
