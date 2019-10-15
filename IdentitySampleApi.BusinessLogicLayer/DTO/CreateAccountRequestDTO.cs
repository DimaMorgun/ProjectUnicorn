namespace IdentitySampleApi.BusinessLogicLayer.DTO
{
    public class CreateAccountRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PlainPassword { get; set; }
    }
}
