﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Cross-reference table mapping products to special offer discounts.
/// </summary>
[PrimaryKey("specialofferid", "productid")]
[Table("specialofferproduct", Schema = "sales")]
public partial class specialofferproduct
{
    /// <summary>
    /// Primary key for SpecialOfferProduct records.
    /// </summary>
    [Key]
    public int specialofferid { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Key]
    public int productid { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("specialofferproducts")]
    public virtual product product { get; set; }

    [InverseProperty("specialofferproduct")]
    public virtual ICollection<salesorderdetail> salesorderdetails { get; set; } = new List<salesorderdetail>();

    [ForeignKey("specialofferid")]
    [InverseProperty("specialofferproducts")]
    public virtual specialoffer specialoffer { get; set; }
}