using System;
using System.ComponentModel.DataAnnotations;

namespace DotNet.CleanArchitecture.Model.Entity.Common
{
    public class Audit : IAudit
    {
		[Required]
		public DateTimeOffset CreationDate { get; set; }

		[Required]
		[StringLength(50)]
		public string CreatedBy { get; set; }

		[Required]
		public DateTimeOffset ModificationDate { get; set; }

		[Required]
		[StringLength(50)]
		public string ModifiedBy { get; set; }

		[Required]
		[StringLength(1)]
		public string RowStatus { get; set; }
	}
}