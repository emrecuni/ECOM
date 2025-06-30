using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Log
    {
        [Key]
        [Column("Id")]
        public int LogId { get; set; }
        public string? TableName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public char ProcessType { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
