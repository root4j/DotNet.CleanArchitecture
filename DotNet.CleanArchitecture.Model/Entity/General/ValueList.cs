using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.CleanArchitecture.Model.Entity.General
{
    [Table("General_ValueList")]
    public class ValueList : Common.Audit
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ValueListCode { get; set; }

        [Required]
        [StringLength(20)]
        public string ValueListCategory { get; set; }

        public int? ListOrder { get; set; }

        [Required]
        [StringLength(45)]
        public string ShortDescription { get; set; }

        [StringLength(90)]
        public string LongDescription { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ValueList valueList && ValueListCode == valueList.ValueListCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ValueListCode);
        }
    }
}