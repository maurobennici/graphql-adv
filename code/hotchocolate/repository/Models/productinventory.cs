﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Product inventory information.
/// </summary>
[PrimaryKey("productid", "locationid")]
[Table("productinventory", Schema = "production")]
public partial class productinventory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Key]
    public int productid { get; set; }

    /// <summary>
    /// Inventory location identification number. Foreign key to Location.LocationID.
    /// </summary>
    [Key]
    public int locationid { get; set; }

    /// <summary>
    /// Storage compartment within an inventory location.
    /// </summary>
    [Required]
    [StringLength(10)]
    public string shelf { get; set; }

    /// <summary>
    /// Storage container on a shelf in an inventory location.
    /// </summary>
    public short bin { get; set; }

    /// <summary>
    /// Quantity of products in the inventory location.
    /// </summary>
    public short quantity { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("locationid")]
    [InverseProperty("productinventories")]
    public virtual location location { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("productinventories")]
    public virtual product product { get; set; }
}