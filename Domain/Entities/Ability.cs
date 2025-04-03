using Domain.Abstractions;

namespace Domain.Entities
{
    public class Ability : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
    }
}
