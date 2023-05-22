using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("warehouse_product")]
    public class WarehouseProduct
    {
        [Key]
        [Column("whproduct_id")]
        public int Id { get; set; }
        [ForeignKey("product")]
        [Column("product_id")]
        public int ProductId { get; set; }
        public Product product { get; set; }
        [ForeignKey("warehouse")]
        [Column("warehouse_id")]
        public int WarehouseId { get; set; }
        public Warehouse warehouse { get; set; }

    }
}
