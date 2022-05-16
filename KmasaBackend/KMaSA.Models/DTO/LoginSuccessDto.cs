namespace KMaSA.Models.DTO
{
    public class LoginSuccessDto
    {
        public string Username { get ; set; }
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
