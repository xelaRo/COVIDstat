using System.Threading.Tasks;

namespace Infrastructure.COVIDstat.JwtProvider
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}