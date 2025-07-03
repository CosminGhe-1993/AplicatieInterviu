using AplicatieInterviu.DTOs;
using AplicatieInterviu.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicatieInterviu.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICompanieService _companieService;

        public LoginModel(IUserService userService, ICompanieService companieService)
        {
            _userService = userService;
            _companieService = companieService;
        }

        [BindProperty]
        public LoginDto Login { get; set; } = new LoginDto();

        public List<SelectListItem> Companies { get; set; } = new List<SelectListItem>();

        public string ErrorMessage { get; set; } = "";

        public async Task OnGetAsync()
        {
            var companii = await _companieService.GetAllAsync();

            Companies = companii.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Login.Company))
            {
                await OnGetAsync();
                ErrorMessage = "Te rog sa selectezi o companie.";
                return Page();
            }

            var user = await _userService.LoginAsync(Login);

            if (user == null)
            {
                await OnGetAsync(); 
                ErrorMessage = "Date de autentificare incorecte.";
                return Page();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);

            if (user.RoleId == 1)
            {
                return RedirectToPage("/AdminDashboard");
            }
            else
            {
                return RedirectToPage("/UserDashboard");
            }
        }
    }
}
