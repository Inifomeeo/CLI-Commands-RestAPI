using System.ComponentModel.DataAnnotations;

namespace CommandApi.Models
{
    public class Command
    {
        public long Id { get; set; }

        [Required]
        public string? HowTo { get; set; }

        [Required]
        public string? Line { get; set; }

        [Required]
        public string? Platform { get; set; }
    }
}