using System.ComponentModel.DataAnnotations;

namespace ParcelManagementSystem.DTOs
{
    public class ParcelCreateDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 20)]
        [RegularExpression(@"^\d{20}$", ErrorMessage = "کد رهگیری باید دقیقاً 20 رقم عددی باشد")]
        public string TrackingCode { get; set; }

        [Required]
        [StringLength(100)]
        public string SenderName { get; set; }

        [Required]
        [StringLength(100)]
        public string RecieverName { get; set; }

        [Required]
        [Range(0.1, 100)]
        public double Weight { get; set; }

        [Required]
        public string DesAddress { get; set; }

        [Required]
        public string Origin { get; set; }


        [Required]
        public string Status { get; set; }
    }
}
