using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("shipment")]
    public class Shipment
    {
        [Key]
        [Column("shipment_id")]
        public int Id { get; set; }
        [ForeignKey("sender")]
        [Column("sender_id")]
        public int SenderId { get; set; }
        public Customer Sender { get; set; }
        [ForeignKey("receiver")]
        [Column("receiver_id")]
        public int ReceiverId { get; set; }
        public Customer Receiver { get; set; }
        [ForeignKey("personnel")]
        [Column("personnel_id")]
        public int PersonnelId { get; set; }
        public Personnel personnel { get; set; }
        [ForeignKey("invoice")]
        [Column("invoice_id")]
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }
        [ForeignKey("source_warehouse")]
        [Column("source_warehouse_id")]
        public int SourceWarehouseId { get; set; }
        public Warehouse sourceWarehouse { get; set; }
        [ForeignKey("destination_warehouse")]
        [Column("destination_warehouse_id")]
        public int DestinationWarehouseId { get; set; }
        public Warehouse destinationWarehouse { get; set; }
        public ICollection<ShipmentProduct> shipmentProducts { get; set; }
    }
}
