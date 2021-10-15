using System.ComponentModel.DataAnnotations;

namespace ExampleGQL.Entities
{
    public class Platform
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string LicenseKey { get; set; }
    }
}