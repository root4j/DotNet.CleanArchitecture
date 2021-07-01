using System;

namespace DotNet.CleanArchitecture.Model.Entity.Common
{
    public interface IAudit
    {
		public DateTimeOffset CreationDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTimeOffset ModificationDate { get; set; }

		public string ModifiedBy { get; set; }

		public string RowStatus { get; set; }
	}
}