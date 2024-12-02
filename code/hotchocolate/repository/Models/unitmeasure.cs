﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Unit of measure lookup table.
/// </summary>
[Table("unitmeasure", Schema = "production")]
public partial class unitmeasure
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    [StringLength(3)]
    public string unitmeasurecode { get; set; }

    /// <summary>
    /// Unit of measure description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("unitmeasurecodeNavigation")]
    public virtual ICollection<billofmaterial> billofmaterials { get; set; } = new List<billofmaterial>();

    [InverseProperty("sizeunitmeasurecodeNavigation")]
    public virtual ICollection<product> productsizeunitmeasurecodeNavigations { get; set; } = new List<product>();

    [InverseProperty("unitmeasurecodeNavigation")]
    public virtual ICollection<productvendor> productvendors { get; set; } = new List<productvendor>();

    [InverseProperty("weightunitmeasurecodeNavigation")]
    public virtual ICollection<product> productweightunitmeasurecodeNavigations { get; set; } = new List<product>();
}