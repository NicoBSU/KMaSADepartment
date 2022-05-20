namespace KMaSA.Models.DTO.Account
{
    public class LoginSuccessDto
    {
        public string Username { get; set; }

        public UserDto User { get; set; }

        public string Token { get; set; }

        public string UserRole { get; set; }
    }
}