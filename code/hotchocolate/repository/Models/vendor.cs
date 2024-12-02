﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Companies from whom Adventure Works Cycles purchases parts or other goods.
/// </summary>
[Table("vendor", Schema = "purchasing")]
public partial class vendor
{
    /// <summary>
    /// Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Vendor account (identification) number.
    /// </summary>
    [Required]
    [StringLength(15)]
    public string accountnumber { get; set; }

    /// <summary>
    /// Company name.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    /// <summary>
    /// 1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average
    /// </summary>
    public short creditrating { get; set; }

    /// <summary>
    /// 0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.
    /// </summary>
    public bool preferredvendorstatus { get; set; }

    /// <summary>
    /// 0 = Vendor no longer used. 1 = Vendor is actively used.
    /// </summary>
    public bool activeflag { get; set; }

    /// <summary>
    /// Vendor URL.
    /// </summary>
    [StringLength(1024)]
    public string purchasingwebserviceurl { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("vendor")]
    public virtual businessentity businessentity { get; set; }

    [InverseProperty("businessentity")]
    public virtual ICollection<productvendor> productvendors { get; set; } = new List<productvendor>();

    [InverseProperty("vendor")]
    public virtual ICollection<purchaseorderheader> purchaseorderheaders { get; set; } = new List<purchaseorderheader>();
}