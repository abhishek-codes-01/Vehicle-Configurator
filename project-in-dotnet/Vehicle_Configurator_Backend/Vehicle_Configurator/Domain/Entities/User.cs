using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vehicle_Configurator.Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("username")]
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; } = string.Empty;

        [Column("password")]
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; } = string.Empty;

        [Column("role")]
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [Column("holding")]
        [JsonPropertyName("holding")]
        public string? Holding { get; set; }


        [Column("st_no")]
        [JsonPropertyName("stNo")]
        public int StNo { get; set; }

        [Column("tel")]
        [JsonPropertyName("tel")]
        public decimal? Tel { get; set; } // changed to string

        [Column("addr")]
        [JsonPropertyName("addr")]
        public string? Addr { get; set; }

        [Column("cell")]
        [JsonPropertyName("cell")]
        public decimal? Cell { get; set; } // changed to string

        [Column("auth_name")]
        [JsonPropertyName("authName")]
        public string? AuthName { get; set; }

        [Column("city")]
        [JsonPropertyName("city")]
        public string? City { get; set; }

        [Column("company_name")]
        [JsonPropertyName("companyName")]
        public string? CompanyName { get; set; }

        [Column("desig")]
        [JsonPropertyName("desig")]
        public string? Desig { get; set; }

        [Column("email")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [Column("pin")]
        [JsonPropertyName("pin")]
        public int Pin { get; set; }

        [Column("reg_no")]
        [JsonPropertyName("regNo")]
        public decimal? RegNo { get; set; } // changed to string

        [Column("state")]
        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
