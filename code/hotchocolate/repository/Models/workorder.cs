﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Manufacturing work orders.
/// </summary>
[Table("workorder", Schema = "production")]
public partial class workorder
{
    /// <summary>
    /// Primary key for WorkOrder records.
    /// </summary>
    [Key]
    public int workorderid { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int productid { get; set; }

    /// <summary>
    /// Product quantity to build.
    /// </summary>
    public int orderqty { get; set; }

    /// <summary>
    /// Quantity that failed inspection.
    /// </summary>
    public short scrappedqty { get; set; }

    /// <summary>
    /// Work order start date.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime startdate { get; set; }

    /// <summary>
    /// Work order end date.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? enddate { get; set; }

    /// <summary>
    /// Work order due date.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime duedate { get; set; }

    /// <summary>
    /// Reason for inspection failure.
    /// </summary>
    public int? scrapreasonid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("workorders")]
    public virtual product product { get; set; }

    [ForeignKey("scrapreasonid")]
    [InverseProperty("workorders")]
    public virtual scrapreason scrapreason { get; set; }

    [InverseProperty("workorder")]
    public virtual ICollection<workorderrouting> workorderroutings { get; set; } = new List<workorderrouting>();
}