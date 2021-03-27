namespace SGM.WebAPI.Core.Autenticacao
{
    public class TokenConfigurations
    {
        public string Secret { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public int Seconds { get; set; }
    }
}
