using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnnalandWebSite.Models
{
    public class MachinesImg
    {
        public string imgpath { get; set; }
        [Key]
        public int idimg { get; set; }
        public int id { get; set; }
        public string imgNAME { get; set; }
        public int IDF { get; set; }

    }
}
