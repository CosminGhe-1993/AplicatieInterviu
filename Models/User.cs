﻿namespace AplicatieInterviu.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
    }
}
