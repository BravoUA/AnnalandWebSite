using System.ComponentModel.DataAnnotations;

namespace AnnalandWebSite.Models
{
    public class FildType
    {
        public string FildTypeName { get; set; }
        [Key]
        public int id { get; set; }
    }
}
