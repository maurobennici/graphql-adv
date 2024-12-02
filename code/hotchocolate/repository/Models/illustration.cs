﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Bicycle assembly diagrams.
/// </summary>
[Table("illustration", Schema = "production")]
public partial class illustration
{
    /// <summary>
    /// Primary key for Illustration records.
    /// </summary>
    [Key]
    public int illustrationid { get; set; }

    /// <summary>
    /// Illustrations used in manufacturing instructions. Stored as XML.
    /// </summary>
    [Column(TypeName = "xml")]
    public string diagram { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("illustration")]
    public virtual ICollection<productmodelillustration> productmodelillustrations { get; set; } = new List<productmodelillustration>();
}