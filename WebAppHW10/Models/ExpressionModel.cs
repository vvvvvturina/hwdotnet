using System.ComponentModel.DataAnnotations;

namespace WebAppHW10.Models
{
    public class ExpressionModel
    {
        [Key]
        public string Expression { get; set; }
        public int Value { get; set; }
    }
}