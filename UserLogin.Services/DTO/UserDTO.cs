namespace UserLogin.Services.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegisteredAt { get; set; }
        //public UserDTO(long id, string firstName, string lastName, string email,
        //    string password, string registerdAt)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Password = password;
        //    RegisteredAt = registerdAt;
        //}

    }
}
