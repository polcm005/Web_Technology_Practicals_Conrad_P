using AOWebApp2.Models;

namespace AOWebApp2.ViewModels
{
    public class ItemsReview
    {
        public Item ItemSubject { get; set; }
        public double averageRating { get; set; }
        public int reviewQuantity { get; set; }
    }
}
