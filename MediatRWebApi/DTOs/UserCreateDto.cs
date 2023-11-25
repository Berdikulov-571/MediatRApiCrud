namespace MediatRWebApi.DTOs
{
    public class UserCreateDto
    {
        public string firstName { get; set; } = default!;
        public string lastName { get; set; } = default!;
        public int Age { get; set; } = default!;
    }
}
