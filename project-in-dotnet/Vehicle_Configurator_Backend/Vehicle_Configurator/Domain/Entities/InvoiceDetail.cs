using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("invoice_detail")]
    public class InvoiceDetail
    {
        [Key]
        [Column("inv_dtl_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvDtlId { get; set; }

        [Column("inv_id")]
        [ForeignKey("Invoice")]
        public int InvId { get; set; }

        public InvoiceHeader Invoice { get; set; }

        [Column("comp_id")]
        [ForeignKey("Component")]
        public int CompId { get; set; }
        public Component Component { get; set; }
    }
}
