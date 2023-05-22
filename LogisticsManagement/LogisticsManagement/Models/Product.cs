using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("unit_price")]
        public string? UnitPrice {get; set; }
        public ICollection<ShipmentProduct> shipmentProducts { get; set; }
        public ICollection<WarehouseProduct> warehouseProducts { get; set; }
    }
}
