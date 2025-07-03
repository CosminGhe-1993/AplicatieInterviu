using AplicatieInterviu.DTOs;
using AplicatieInterviu.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicatieInterviu.Pages
{
    public class UserDashboardModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICompanieService _companieService;

        public UserDashboardModel(IUserService userService, ICompanieService companieService)
        {
            _userService = userService;
            _companieService = companieService;
        }

        public UserDto Utilizator { get; set; }
        public CompanieDto Companie { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login");

            Utilizator = await _userService.GetByIdAsync(userId.Value);

            if (Utilizator == null)
                return RedirectToPage("/Login");

            Companie = await _companieService.GetByIdAsync(Utilizator.CompanyId);

            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }

    }
}
