namespace IdentitySampleApi.BusinessLogicLayer.DTO.Account
{
    public class BaseAccountTokenResponseDTO : BaseAccountResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
