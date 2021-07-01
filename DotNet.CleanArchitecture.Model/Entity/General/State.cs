using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.CleanArchitecture.Model.Entity.General
{
	[Table("General_State")]
	public class State : Common.Audit
    {
		[Key]
		[Required]
		[StringLength(10)]
		public string StateCode { get; set; }

		[Required]
		[StringLength(150)]
		public string StateName { get; set; }

		[Required]
		[StringLength(3)]
		public string CountryCode { get; set; }

		[StringLength(20)]
		public string Latitude { get; set; }

		[StringLength(20)]
		public string Longitude { get; set; }

		public virtual Country Country { get; set; }

		public override bool Equals(object obj)
        {
            return obj is State state && StateCode == state.StateCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StateCode);
        }
    }
}