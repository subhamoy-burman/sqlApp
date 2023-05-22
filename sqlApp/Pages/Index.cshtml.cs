using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlApp.Models;
using sqlApp.Services;

namespace sqlApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> ProductList;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            ProductList = productService.GetProducts();

        }
    }
}