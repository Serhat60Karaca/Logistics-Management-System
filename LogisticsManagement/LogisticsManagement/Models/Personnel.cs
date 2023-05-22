using LogisticsManagement.Models.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("personnel")]
    public class Personnel
    {
        [Key]
        [Column("personnel_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("contact")]
        public string? Contact { get; set; }
        //public virtual AppUser AppUser { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}