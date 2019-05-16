using ContosoPets.Ui.Models;
using ContosoPets.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoPets.Ui.Extensions;

namespace ContosoPets.Ui.Areas.Admin.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;

        public string Error { get; set; }
        public string AntiforgeryToken => HttpContext.GetAntiforgeryTokenForJs();
        public IEnumerable<Product> Products { get; private set; } = new List<Product>();

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet()
        {
            try
            {
                Products = await _productService.GetProducts();
            }
            catch
            {
                Products = new List<Product>();
                Error = "Unable to retrieve products.";
            }
        }

        public IActionResult OnPostEdit(int productId)
        {
            return RedirectToPage("Edit", new { id = productId });
        }
    
        public async Task<IActionResult> OnDelete(int productId)
        {
            try
            {
                await _productService.DeleteProduct(productId);
                return new NoContentResult();
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }
}