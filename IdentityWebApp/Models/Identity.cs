namespace IdentityWebApp.Models
{
    public class Identity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
