﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// High-level product categorization.
/// </summary>
[Table("productcategory", Schema = "production")]
public partial class productcategory
{
    /// <summary>
    /// Primary key for ProductCategory records.
    /// </summary>
    [Key]
    public int productcategoryid { get; set; }

    /// <summary>
    /// Category description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("productcategory")]
    public virtual ICollection<productsubcategory> productsubcategories { get; set; } = new List<productsubcategory>();
}