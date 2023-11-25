using System.ComponentModel.DataAnnotations;

namespace MediatRWebApi.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string firstName { get; set; } = default!;
        public string lastName { get; set; } = default!;
        public int Age { get; set; } = default!;
    }
}
