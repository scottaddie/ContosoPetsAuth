using ContosoPets.Ui.Models;
using ContosoPets.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoPets.Ui.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;

        public IEnumerable<Product> Products { get; private set; } = new List<Product>();

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet()
        {
            Products = await _productService.GetProducts();
        }

        public IActionResult OnPostEdit(int productId)
        {
            return RedirectToPage("Edit", new { id = productId });
        }

        public async Task<IActionResult> OnPostDelete(int productId)
        {
            await _productService.DeleteProduct(productId);

            return RedirectToPage();
        }
    }
}