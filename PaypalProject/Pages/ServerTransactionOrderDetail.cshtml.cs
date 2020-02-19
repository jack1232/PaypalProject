using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaypalProject.Models;

namespace PaypalProject
{
    public class ServerTransactionOrderDetailModel : PageModel
    {
        [BindProperty] 
        public OrderDetailViewModel Input { get; set; }

        public void OnGet()
        {
            Input = new OrderDetailViewModel();
            Input.Calculate();
        }

        public void OnPost()
        {
            Input.Calculate();
        }
    }
}