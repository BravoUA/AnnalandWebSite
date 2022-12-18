using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace AnnalandWebSite
{
	public  class HashingL_P
	{

			public string SaltString;

			const int keySize = 10;
			const int iterations = 350000;
			

			HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
			public string HashString(string str, out byte[] salt)
			{
			SaltString = "";
				salt = RandomNumberGenerator.GetBytes(keySize);
				
				var hash = Rfc2898DeriveBytes.Pbkdf2(
					Encoding.UTF8.GetBytes(str),
					salt,
					iterations,
					hashAlgorithm,
					keySize);
			foreach (byte t in salt) {
				SaltString += t.ToString()+".";
			}
				
				return Convert.ToHexString(hash);
			}

			public bool VerifyString(string strVerify, string hash, string saltS)
			{
			
			string[] saltArrry = saltS.Split(".");

			byte[] pureSalt = new byte[keySize];
			for (int i = 0; i < saltArrry.Length - 1; i++)
			{
				pureSalt[i] = Convert.ToByte(saltArrry[i]);
			}
			var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(strVerify, pureSalt, iterations, hashAlgorithm, keySize);
				return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
			}

	}
}
