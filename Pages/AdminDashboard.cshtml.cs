using AplicatieInterviu.DTOs;
using AplicatieInterviu.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicatieInterviu.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICompanieService _companieService;
        private readonly IEmailService _emailService;

        public AdminDashboardModel(IUserService userService, ICompanieService companieService, IEmailService emailService)
        {
            _userService = userService;
            _companieService = companieService;
            _emailService = emailService;
        }

        [BindProperty]
        public string Mesaj { get; set; }

        public UserDto Utilizator { get; set; }
        public CompanieDto Companie { get; set; }
        public List<UserDto> Utilizatori { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login");

            Utilizator = await _userService.GetByIdAsync(userId.Value);

            if (Utilizator == null)
                return RedirectToPage("/Login");

            Companie = await _companieService.GetByIdAsync(Utilizator.CompanyId);
            Utilizatori = await _userService.GetUsersByCompanyIdAsync(Companie.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string emailInvitat, string numeInvitat, string prenumeInvitat)
        {
            await LoadDataAsync();

            if (string.IsNullOrEmpty(emailInvitat) || !emailInvitat.Contains("@") ||
                string.IsNullOrWhiteSpace(numeInvitat) || string.IsNullOrWhiteSpace(prenumeInvitat))
            {
                Mesaj = "Te rog sa completezi toate campurile corect.";
                return Page();
            }

            try
            {
                var subiect = "Link inregistrare";
                var linkInregistrare = $"https://localhost:7187/RegisterUser?CompanieName={Uri.EscapeDataString(Companie.Name)}";

                var text = $"Buna ziua {numeInvitat} {prenumeInvitat},\n" +
                           $"{Utilizator.Nume} {Utilizator.Prenume} te invita sa te inregistrezi la aplicatia noastra.\n" +
                           $"Acceseaza link-ul urmator pentru inregistrare:\n{linkInregistrare}";

                await _emailService.SendEmailAsync(emailInvitat, subiect, text);

                Mesaj = "Invitatie trimisa cu succes.";
            }
            catch (Exception)
            {
                Mesaj = "A aparut o eroare la trimiterea invitatiei.";
            }

            await LoadDataAsync();

            return Page();
        }


        private async Task LoadDataAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            Utilizator = await _userService.GetByIdAsync(userId.Value);
            Companie = await _companieService.GetByIdAsync(Utilizator.CompanyId);
            Utilizatori = await _userService.GetUsersByCompanyIdAsync(Companie.Id);
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Clear(); 
            return RedirectToPage("/Login");
        }
    }
}
