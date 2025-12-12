using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.ViewModels
{
    public class ReservationViewModel
    {
        [Required(ErrorMessage = "Името е задължително")]
        [Display(Name = "Име")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Имейлът е задължителен")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес")]
        [Display(Name = "Имейл")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Display(Name = "Телефон")]
        public string? CustomerPhone { get; set; }

        [Required(ErrorMessage = "Датата и часът са задължителни")]
        [Display(Name = "Дата и час")]
        public DateTime ReservationDateTime { get; set; } = DateTime.Now.AddDays(1).Date.AddHours(18);

        [Required(ErrorMessage = "Броят гости е задължителен")]
        [Range(1, 20, ErrorMessage = "Броят гости трябва да е между 1 и 20")]
        [Display(Name = "Брой гости")]
        public int NumberOfGuests { get; set; } = 2;

        [Display(Name = "Бележки (по избор)")]
        public string? Notes { get; set; }

        public Guid? SelectedTableId { get; set; }
    }
}





