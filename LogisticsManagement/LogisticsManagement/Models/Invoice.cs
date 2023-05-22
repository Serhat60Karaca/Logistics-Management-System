using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models
{
    [Table("invoice")]
    public class Invoice
    {
        [Key]
        [Column("invoice_id")]
        public int Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}
