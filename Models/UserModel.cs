using System.ComponentModel.DataAnnotations;

namespace Lr6.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я обов'язкове")]
        [StringLength(20, ErrorMessage = "Ім'я не може бути довшим за 20 символів")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z\s]*$", ErrorMessage = "Ім'я може містити лише українські або англійські літери та пробіли")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Рік народження обов'язковий")]
        [Range(1900, 2008, ErrorMessage = "Нажаль, для замовлення Вам має бути не менше 16 років")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "Логін обов'язковий")]
        [StringLength(20, ErrorMessage = "Логін не може бути довшим за 20 символів")]
        [RegularExpression(@"^[a-zA-Z0-9_\.]*$", ErrorMessage = "Логін може містити лише англійські літери, цифри, _ та .")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обов'язковий")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Пароль повинен бути від 5 до 20 символів")]
        [RegularExpression(@"^[a-zA-Z0-9_\.]*$", ErrorMessage = "Пароль може містити лише англійські літери, цифри та _.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }
    }
}