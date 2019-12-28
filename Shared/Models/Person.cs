namespace SharedAll.Models
{
    public class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Deleted { get; set; }
        public int? UserActionId { get; set; }
    }
}
