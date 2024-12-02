﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Sale discounts lookup table.
/// </summary>
[Table("specialoffer", Schema = "sales")]
public partial class specialoffer
{
    /// <summary>
    /// Primary key for SpecialOffer records.
    /// </summary>
    [Key]
    public int specialofferid { get; set; }

    /// <summary>
    /// Discount description.
    /// </summary>
    [Required]
    [StringLength(255)]
    public string description { get; set; }

    /// <summary>
    /// Discount precentage.
    /// </summary>
    public decimal discountpct { get; set; }

    /// <summary>
    /// Discount type category.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string type { get; set; }

    /// <summary>
    /// Group the discount applies to such as Reseller or Customer.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string category { get; set; }

    /// <summary>
    /// Discount start date.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime startdate { get; set; }

    /// <summary>
    /// Discount end date.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime enddate { get; set; }

    /// <summary>
    /// Minimum discount percent allowed.
    /// </summary>
    public int minqty { get; set; }

    /// <summary>
    /// Maximum discount percent allowed.
    /// </summary>
    public int? maxqty { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("specialoffer")]
    public virtual ICollection<specialofferproduct> specialofferproducts { get; set; } = new List<specialofferproduct>();
}