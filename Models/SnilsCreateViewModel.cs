using System.ComponentModel.DataAnnotations;

namespace SnilsList21.Models
{
    public class SnilsCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести значение")]
        [StringLength(11,
            ErrorMessage = "Номер должно содержать 11 символов")]
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
