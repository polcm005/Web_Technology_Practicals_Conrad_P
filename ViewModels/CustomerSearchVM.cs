using Microsoft.AspNetCore.Mvc.Rendering;

namespace AOWebApp2.ViewModels
{
    public class CustomerSearchVM
    {
        public string SearchText { get; set; }
        public string Suburb { get; set; }
        public SelectList SuburbList { get; set; }
        public List<Models.Customer> CustomerList { get; set; }
    }
}
