using System;

namespace Infrastructure.COVIDstat.JwtProvider
{
    public class Token
    {
        public string Id { get; }
        public string AuthToken { get; }
        public int ExpiresIn { get; }
        public DateTime ExpirationDate { get; }

        public Token(string id, string authToken, int expiresIn, DateTime expirationDate)
        {
            Id = id;
            AuthToken = authToken;
            ExpiresIn = expiresIn;
            ExpirationDate = expirationDate;
        }
    }
}