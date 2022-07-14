using System.ComponentModel.DataAnnotations;

namespace SnilsList21.Models
{
    public class SnilsCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести название")]
        [StringLength(126, MinimumLength = 9,
            ErrorMessage = "Номер должно содержать не менее 11 и не более 126 символов")]
        [Display(Name = "Number")]
        public string Number { get; set; }

        public SnilsCreateViewModel()
        {
        }
        public SnilsCreateViewModel(Snils model)
        {
        }
    }
}
