using System.ComponentModel.DataAnnotations;

namespace Lr6.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Кількість піц обов'язкова")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість піц повинна бути додатнім цілим числом")]
        public int PizzaCount { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }

        public decimal TotalPrice => OrderItems?.Sum(item => item.SelectedPizza?.Price ?? 0) ?? 0;

        public OrderViewModel()
        {
            OrderItems = new List<OrderItemViewModel>();
        }
    }

    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public ProductModel SelectedPizza { get; set; }
        public int SelectedPizzaId { get; set; }
    }
}