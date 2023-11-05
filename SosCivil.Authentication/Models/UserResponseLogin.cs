namespace SosCivil.Authentication.Models
{
    public class UserResponseLogin
    {
        public string AccessToken { get; set; }
        public double ExpireIn { get; set; }
        public UserToken UserToken{ get; set; }
    }

}
