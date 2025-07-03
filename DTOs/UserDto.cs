namespace AplicatieInterviu.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
    }
}
