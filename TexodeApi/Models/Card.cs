using System.ComponentModel.DataAnnotations;

namespace TexodeApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string Image { get; set; }
    }
}