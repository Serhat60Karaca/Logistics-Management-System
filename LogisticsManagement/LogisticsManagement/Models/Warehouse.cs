using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("warehouse")]
    public class Warehouse
    {
        [Key]
        [Column("warehouse_id")]
        public int Id { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }
        public ICollection<Shipment> DestinationShipments { get; set; }
        public ICollection<Shipment> SourceShipments { get; set; }
        public ICollection<WarehouseProduct> warehouseProducts { get; set; }
    }
}