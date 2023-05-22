using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("shipment_product")]
    public class ShipmentProduct
    {
        [Key]
        [Column("sp_id")]
        public int Id { get; set; }
        [ForeignKey("shipment")]
        [Column("shipment_id")]
        public int ShipmentId { get; set; }
        public Shipment shipment { get; set; }
        [ForeignKey("product")]
        [Column("product_id")]
        public int ProductId { get; set; }
        public Product product { get; set; }

    }
}
