using LogisticsManagement.Models.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("contact")]
        public string? Contact { get; set; }
        public virtual AppUser AppUser { get; set; }
        public ICollection<Shipment> Sentshipments { get; set; }
        public ICollection<Shipment> ReceivedShipments { get; set; }
    }
}
