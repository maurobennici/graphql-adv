﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Types of addresses stored in the Address table.
/// </summary>
[Table("addresstype", Schema = "person")]
public partial class addresstype
{
    /// <summary>
    /// Primary key for AddressType records.
    /// </summary>
    [Key]
    public int addresstypeid { get; set; }

    /// <summary>
    /// Address type description. For example, Billing, Home, or Shipping.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("addresstype")]
    public virtual ICollection<businessentityaddress> businessentityaddresses { get; set; } = new List<businessentityaddress>();
}