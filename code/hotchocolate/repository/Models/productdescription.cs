﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Product descriptions in several languages.
/// </summary>
[Table("productdescription", Schema = "production")]
public partial class productdescription
{
    /// <summary>
    /// Primary key for ProductDescription records.
    /// </summary>
    [Key]
    public int productdescriptionid { get; set; }

    /// <summary>
    /// Description of the product.
    /// </summary>
    [Required]
    [StringLength(400)]
    public string description { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("productdescription")]
    public virtual ICollection<productmodelproductdescriptionculture> productmodelproductdescriptioncultures { get; set; } = new List<productmodelproductdescriptionculture>();
}