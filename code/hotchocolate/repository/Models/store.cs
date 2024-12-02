﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Customers (resellers) of Adventure Works products.
/// </summary>
[Table("store", Schema = "sales")]
public partial class store
{
    /// <summary>
    /// Primary key. Foreign key to Customer.BusinessEntityID.
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Name of the store.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    /// <summary>
    /// ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    public int? salespersonid { get; set; }

    /// <summary>
    /// Demographic informationg about the store such as the number of employees, annual sales and store type.
    /// </summary>
    [Column(TypeName = "xml")]
    public string demographics { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("store")]
    public virtual businessentity businessentity { get; set; }

    [InverseProperty("store")]
    public virtual ICollection<customer> customers { get; set; } = new List<customer>();

    [ForeignKey("salespersonid")]
    [InverseProperty("stores")]
    public virtual salesperson salesperson { get; set; }
}