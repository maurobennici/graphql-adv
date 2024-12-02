﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Sales performance tracking.
/// </summary>
[PrimaryKey("businessentityid", "quotadate")]
[Table("salespersonquotahistory", Schema = "sales")]
public partial class salespersonquotahistory
{
    /// <summary>
    /// Sales person identification number. Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Sales quota date.
    /// </summary>
    [Key]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime quotadate { get; set; }

    /// <summary>
    /// Sales quota amount.
    /// </summary>
    public decimal salesquota { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("salespersonquotahistories")]
    public virtual salesperson businessentity { get; set; }
}