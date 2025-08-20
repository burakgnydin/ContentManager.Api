using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Contact.Repositories.DatabaseSettings
{
    public class MongoSettings
    {
        [Required] public string DatabaseName { get; set; } = null!;
        [Required] public string ConnectionString { get; set; } = null!;
    }
}
