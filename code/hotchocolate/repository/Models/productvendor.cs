﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Cross-reference table mapping vendors with the products they supply.
/// </summary>
[PrimaryKey("productid", "businessentityid")]
[Table("productvendor", Schema = "purchasing")]
public partial class productvendor
{
    /// <summary>
    /// Primary key. Foreign key to Product.ProductID.
    /// </summary>
    [Key]
    public int productid { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Vendor.BusinessEntityID.
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// The average span of time (in days) between placing an order with the vendor and receiving the purchased product.
    /// </summary>
    public int averageleadtime { get; set; }

    /// <summary>
    /// The vendor&apos;s usual selling price.
    /// </summary>
    public decimal standardprice { get; set; }

    /// <summary>
    /// The selling price when last purchased.
    /// </summary>
    public decimal? lastreceiptcost { get; set; }

    /// <summary>
    /// Date the product was last received by the vendor.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? lastreceiptdate { get; set; }

    /// <summary>
    /// The maximum quantity that should be ordered.
    /// </summary>
    public int minorderqty { get; set; }

    /// <summary>
    /// The minimum quantity that should be ordered.
    /// </summary>
    public int maxorderqty { get; set; }

    /// <summary>
    /// The quantity currently on order.
    /// </summary>
    public int? onorderqty { get; set; }

    /// <summary>
    /// The product&apos;s unit of measure.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string unitmeasurecode { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("productvendors")]
    public virtual vendor businessentity { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("productvendors")]
    public virtual product product { get; set; }

    [ForeignKey("unitmeasurecode")]
    [InverseProperty("productvendors")]
    public virtual unitmeasure unitmeasurecodeNavigation { get; set; }
}