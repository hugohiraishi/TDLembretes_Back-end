namespace TDLembretes.Services
{
    public class IpService
    {

       private readonly IHttpContextAccessor _httpContextAccessor;

       public IpService(IHttpContextAccessor httpContextAccessor)
       {
           _httpContextAccessor = httpContextAccessor;
       }

        public string ObterIp()
        {
            var ipCliente = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(ipCliente))
            {
                ipCliente = _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            }

            return ipCliente;
        }


    }
}
