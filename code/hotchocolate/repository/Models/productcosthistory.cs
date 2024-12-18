﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Changes in the cost of a product over time.
/// </summary>
[PrimaryKey("productid", "startdate")]
[Table("productcosthistory", Schema = "production")]
public partial class productcosthistory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID
    /// </summary>
    [Key]
    public int productid { get; set; }

    /// <summary>
    /// Product cost start date.
    /// </summary>
    [Key]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime startdate { get; set; }

    /// <summary>
    /// Product cost end date.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? enddate { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    public decimal standardcost { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("productcosthistories")]
    public virtual product product { get; set; }
}