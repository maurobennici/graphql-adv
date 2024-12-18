﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Sales representative transfers to other sales territories.
/// </summary>
[PrimaryKey("businessentityid", "startdate", "territoryid")]
[Table("salesterritoryhistory", Schema = "sales")]
public partial class salesterritoryhistory
{
    /// <summary>
    /// Primary key. The sales rep.  Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Primary key. Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    [Key]
    public int territoryid { get; set; }

    /// <summary>
    /// Primary key. Date the sales representive started work in the territory.
    /// </summary>
    [Key]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime startdate { get; set; }

    /// <summary>
    /// Date the sales representative left work in the territory.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? enddate { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("salesterritoryhistories")]
    public virtual salesperson businessentity { get; set; }

    [ForeignKey("territoryid")]
    [InverseProperty("salesterritoryhistories")]
    public virtual salesterritory territory { get; set; }
}