using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.CleanArchitecture.Model.Entity.General
{
	[Table("General_City")]
	public class City : Common.Audit
	{
		[Key]
		[Required]
		[StringLength(15)]
		public string CityCode { get; set; }

		[Required]
		[StringLength(10)]
		public string StateCode { get; set; }

		[Required]
		[StringLength(150)]
		public string CityName { get; set; }

		[StringLength(20)]
		public string Latitude { get; set; }

		[StringLength(20)]
		public string Longitude { get; set; }

		public virtual State State { get; set; }

		public override bool Equals(object obj)
		{
			return obj is City city && CityCode == city.CityCode;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(CityCode);
		}
	}
}