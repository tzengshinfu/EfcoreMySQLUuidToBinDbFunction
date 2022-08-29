using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EfcoreMySQLUuidToBinDbFunction.Tables
{
    public partial class test_table
    {
        [Key]
        [MaxLength(16)]
        public byte[] uuid_to_bin_column { get; set; } = null!;
        [StringLength(32)]
        public string? uuid_column { get; set; }
        [StringLength(255)]
        public string? remark { get; set; }
    }
}
