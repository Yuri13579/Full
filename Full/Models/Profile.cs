namespace Back.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public string Gender { get; set; }
        public bool Deleted { get; set; }
        public int? UserActionId { get; set; }

        //  public DateTime DOB { get; set; }
    }
}
