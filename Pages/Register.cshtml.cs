using AplicatieInterviu.DTOs;
using AplicatieInterviu.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicatieInterviu.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public CompanieDto CompanieDto { get; set; } = new CompanieDto();

        [BindProperty]
        public UserDto UserDto { get; set; } = new UserDto();

        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                        
            UserDto.RoleId = 1;

            await _userService.RegisterUserWithCompanyAsync(UserDto, CompanieDto, Password);

            return RedirectToPage("/Login");
        }
    }
}
