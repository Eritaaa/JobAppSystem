using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobAppSystem.Models
{
    public class Konkursi
    {
        [Key]
        public int KonkursiId { get; set; }
        [Column("nvarchar(250)")]
        public string Titulli { get; set; }
        [Column("varchar(100)")]
        public string Pozicioni { get; set; }
        public int EksperiencaENevojshme { get; set; }
        public DateTime DataEHapjes { get; set; }
        public DateTime DataEMbylljes { get; set; }
    }
}
