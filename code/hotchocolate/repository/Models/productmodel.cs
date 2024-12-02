﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Product model classification.
/// </summary>
[Table("productmodel", Schema = "production")]
public partial class productmodel
{
    /// <summary>
    /// Primary key for ProductModel records.
    /// </summary>
    [Key]
    public int productmodelid { get; set; }

    /// <summary>
    /// Product model description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    /// <summary>
    /// Detailed product catalog information in xml format.
    /// </summary>
    [Column(TypeName = "xml")]
    public string catalogdescription { get; set; }

    /// <summary>
    /// Manufacturing instructions in xml format.
    /// </summary>
    [Column(TypeName = "xml")]
    public string instructions { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("productmodel")]
    public virtual ICollection<productmodelillustration> productmodelillustrations { get; set; } = new List<productmodelillustration>();

    [InverseProperty("productmodel")]
    public virtual ICollection<productmodelproductdescriptionculture> productmodelproductdescriptioncultures { get; set; } = new List<productmodelproductdescriptionculture>();

    [InverseProperty("productmodel")]
    public virtual ICollection<product> products { get; set; } = new List<product>();
}