using AplicatieInterviu.DTOs;
using AplicatieInterviu.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicatieInterviu.Pages
{
    public class RegisterUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICompanieService _companieService;

        public RegisterUserModel(IUserService userService, ICompanieService companieService)
        {
            _userService = userService;
            _companieService = companieService;
        }

        [BindProperty]
        public UserDto User { get; set; } = new UserDto();

        [BindProperty]
        public string Parola { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CompanieName { get; set; }

        public string Mesaj { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrWhiteSpace(CompanieName))
            {
                Mesaj = "Compania nu este specificata.";
                return Page();
            }

            var companie = await _companieService.GetByNameAsync(CompanieName);
            if (companie == null)
            {
                Mesaj = "Compania nu exista.";
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var companie = await _companieService.GetByNameAsync(CompanieName);
            if (companie == null)
            {
                Mesaj = "Compania nu a fost gasita.";
                return Page();
            }

            User.CompanyId = companie.Id;

            try
            {

                await _userService.AddAsync(User, Parola);
                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                Mesaj = "A aparut o eroare la inregistrare.";
                return Page();
            }
        }
    }
}
