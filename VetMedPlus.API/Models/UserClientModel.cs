namespace VetMedPlus.API.Models
{
    public class UserClientModel
    {
        public int UserTypeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int StreetNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }
}
