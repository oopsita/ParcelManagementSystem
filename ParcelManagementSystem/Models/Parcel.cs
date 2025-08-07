using System.ComponentModel.DataAnnotations;

namespace ParcelManagementSystem.Models
{
    public class Parcel
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="کد پیگیری اجباری است")]
        [StringLength(100)] 
        public string TrackingCode { get; set; }
        public string? ParcelType { get; set; }
        [Range(0.1, 100, ErrorMessage = "وزن باید بین ۰.۱ تا ۱۰۰ کیلوگرم باشد")]
        public double Weight { get; set; }
        public DateTime DateAccepted { get; set; }

        [Required(ErrorMessage ="نام فرستنده نباید بیشتر از 100 حرف باشد")]
        [StringLength(100)]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "نام گیرنده نباید بیشتر از 100 حرف باشد")]
        [StringLength(100)]
        public string RecieverName { get; set; }

        [Required(ErrorMessage ="آدرس پستی را با دقت وارد کنید")]
        
        public string DesAddress { get; set; }
        public string Origin  { get; set; }
        public string Status { get; set; }
        public bool Insured { get; set; }
        public bool Restant { get; set; }



    }
}
