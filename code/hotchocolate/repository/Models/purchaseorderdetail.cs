﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Individual products associated with a specific purchase order. See PurchaseOrderHeader.
/// </summary>
[PrimaryKey("purchaseorderid", "purchaseorderdetailid")]
[Table("purchaseorderdetail", Schema = "purchasing")]
public partial class purchaseorderdetail
{
    /// <summary>
    /// Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.
    /// </summary>
    [Key]
    public int purchaseorderid { get; set; }

    /// <summary>
    /// Primary key. One line number per purchased product.
    /// </summary>
    [Key]
    public int purchaseorderdetailid { get; set; }

    /// <summary>
    /// Date the product is expected to be received.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime duedate { get; set; }

    /// <summary>
    /// Quantity ordered.
    /// </summary>
    public short orderqty { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int productid { get; set; }

    /// <summary>
    /// Vendor&apos;s selling price of a single product.
    /// </summary>
    public decimal unitprice { get; set; }

    /// <summary>
    /// Quantity actually received from the vendor.
    /// </summary>
    [Precision(8, 2)]
    public decimal receivedqty { get; set; }

    /// <summary>
    /// Quantity rejected during inspection.
    /// </summary>
    [Precision(8, 2)]
    public decimal rejectedqty { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("purchaseorderdetails")]
    public virtual product product { get; set; }

    [ForeignKey("purchaseorderid")]
    [InverseProperty("purchaseorderdetails")]
    public virtual purchaseorderheader purchaseorder { get; set; }
}