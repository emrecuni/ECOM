namespace ECOM_API.Data.DTOs
{
    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public string? Name { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
