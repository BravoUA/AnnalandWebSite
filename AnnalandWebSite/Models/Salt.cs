using System.ComponentModel.DataAnnotations;

namespace AnnalandWebSite.Models
{
	public class Salt
	{
		public string SaltPassword { get; set; }
		public string SaltEmail { get; set; }
		[Key]
        public int idSalt { get; set; }

	}
}
