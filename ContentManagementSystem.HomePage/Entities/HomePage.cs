using ContentManagementSystem.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContentManagementSystem.HomePage.Entities
{
    public class HomePage : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
