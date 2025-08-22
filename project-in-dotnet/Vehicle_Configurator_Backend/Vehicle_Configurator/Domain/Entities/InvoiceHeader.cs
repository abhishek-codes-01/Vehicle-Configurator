using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Vehicle_Configurator.Domain.Entities;

[Table("invoice_header")]
public class InvoiceHeader
{
    [Key]
    [Column("inv_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvId { get; set; }

    [JsonPropertyName("invDate")]
    [Column("inv_date")]
    public DateTime InvDate { get; set; }

    [JsonPropertyName("totalAmt")]
    [Column("total_amt")]
    public double TotalAmt { get; set; }

    [JsonPropertyName("tax")]
    [Column("tax")]
    public double Tax { get; set; }

    [JsonPropertyName("amt")]
    [Column("amt")]
    public double Amt { get; set; }

    public List<InvoiceDetail>? Details { get; set; } = new();


    [JsonPropertyName("customerDetail")]
    [Column("customer_detail")]
    public string CustomerDetail { get; set; }

    [JsonPropertyName("modelId")]
    [Column("model_id")]
    public int ModelId { get; set; }

    [ValidateNever]
    [JsonIgnore]
    public Model? Model { get; set; }
}
