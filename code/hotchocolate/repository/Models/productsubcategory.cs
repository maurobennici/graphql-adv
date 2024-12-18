﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Product subcategories. See ProductCategory table.
/// </summary>
[Table("productsubcategory", Schema = "production")]
public partial class productsubcategory
{
    /// <summary>
    /// Primary key for ProductSubcategory records.
    /// </summary>
    [Key]
    public int productsubcategoryid { get; set; }

    /// <summary>
    /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
    /// </summary>
    public int productcategoryid { get; set; }

    /// <summary>
    /// Subcategory description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("productcategoryid")]
    [InverseProperty("productsubcategories")]
    public virtual productcategory productcategory { get; set; }

    [InverseProperty("productsubcategory")]
    public virtual ICollection<product> products { get; set; } = new List<product>();
}