namespace AuthenticationAPI.DTO
{
    public class AuthResponseDTO
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string? Token { get; set;  }

        public DateTime Expiration {  get; set; }

        public string? RefreshToken {  get; set; }

    }
}
