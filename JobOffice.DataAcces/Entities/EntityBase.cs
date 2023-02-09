using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
