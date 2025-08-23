using Microsoft.AspNetCore.Mvc.Rendering;

namespace AOWebApp2.ViewModels
{
    public class ItemSearchViewModel
    {
        public string SearchText { get; set; }
        public int? CategoryId { get; set; }
        public SelectList CategoryList { get; set; }
        public List<Models.Item> ItemList { get; set; }
    }
}
