using System;

namespace PhotoryModels
{
    public class TokenViewModel
    {
        public string Token { get; set; }

        public string Role { get; set; }
        public DateTime Expiration { get; set; }

        public string Id { get; set; }
    }
}