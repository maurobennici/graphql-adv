﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Sales representative current information.
/// </summary>
[Table("salesperson", Schema = "sales")]
public partial class salesperson
{
    /// <summary>
    /// Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    public int? territoryid { get; set; }

    /// <summary>
    /// Projected yearly sales.
    /// </summary>
    public decimal? salesquota { get; set; }

    /// <summary>
    /// Bonus due if quota is met.
    /// </summary>
    public decimal bonus { get; set; }

    /// <summary>
    /// Commision percent received per sale.
    /// </summary>
    public decimal commissionpct { get; set; }

    /// <summary>
    /// Sales total year to date.
    /// </summary>
    public decimal salesytd { get; set; }

    /// <summary>
    /// Sales total of previous year.
    /// </summary>
    public decimal saleslastyear { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("salesperson")]
    public virtual employee businessentity { get; set; }

    [InverseProperty("salesperson")]
    public virtual ICollection<salesorderheader> salesorderheaders { get; set; } = new List<salesorderheader>();

    [InverseProperty("businessentity")]
    public virtual ICollection<salespersonquotahistory> salespersonquotahistories { get; set; } = new List<salespersonquotahistory>();

    [InverseProperty("businessentity")]
    public virtual ICollection<salesterritoryhistory> salesterritoryhistories { get; set; } = new List<salesterritoryhistory>();

    [InverseProperty("salesperson")]
    public virtual ICollection<store> stores { get; set; } = new List<store>();

    [ForeignKey("territoryid")]
    [InverseProperty("salespeople")]
    public virtual salesterritory territory { get; set; }
}