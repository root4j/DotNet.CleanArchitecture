using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.CleanArchitecture.Model.Entity.General
{
	[Table("General_Country")]
	public class Country : Common.Audit
	{
		[Key]
		[Required]
		[StringLength(3)]
		public string CountryCode { get; set; }

		[Required]
		[StringLength(150)]
		public string CountryName { get; set; }

		[Required]
		[StringLength(2)]
		public string Alfa2Code { get; set; }

		[Required]
		[StringLength(3)]
		public string NumberCode { get; set; }

		[Required]
		[StringLength(10)]
		public string InternetCode { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Country country && CountryCode == country.CountryCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CountryCode);
        }
    }
}