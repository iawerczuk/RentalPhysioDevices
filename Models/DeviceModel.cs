using System.ComponentModel.DataAnnotations;

namespace PhysioRental.Models
{
    public class DeviceModel
    {
        public int ID { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Dostępność")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Czy wypożyczony")]
        public bool IsRented { get; internal set; }
    }
}