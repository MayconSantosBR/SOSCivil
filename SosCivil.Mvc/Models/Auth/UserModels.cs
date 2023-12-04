namespace SosCivil.Mvc.Models.Auth
{
    public class UsuarioRespostaLogin 
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UserToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email{ get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }

    public class UsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
