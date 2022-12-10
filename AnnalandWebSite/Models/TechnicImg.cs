using System.ComponentModel.DataAnnotations;

namespace AnnalandWebSite.Models
{
    public class TechnicImg
    {
        public string TechnicImgPath { get; set; }
        [Key]
        public int IdImg { get; set; }
        public int id { get; set; }
        public string TechnicImgNAME { get; set; }
        public int IDF { get; set; }
    }
}