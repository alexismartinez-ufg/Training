namespace UsersCrudWithFluentValidations.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
    }
}
