﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Product inventory and manufacturing locations.
/// </summary>
[Table("location", Schema = "production")]
public partial class location
{
    /// <summary>
    /// Primary key for Location records.
    /// </summary>
    [Key]
    public int locationid { get; set; }

    /// <summary>
    /// Location description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    /// <summary>
    /// Standard hourly cost of the manufacturing location.
    /// </summary>
    public decimal costrate { get; set; }

    /// <summary>
    /// Work capacity (in hours) of the manufacturing location.
    /// </summary>
    [Precision(8, 2)]
    public decimal availability { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("location")]
    public virtual ICollection<productinventory> productinventories { get; set; } = new List<productinventory>();

    [InverseProperty("location")]
    public virtual ICollection<workorderrouting> workorderroutings { get; set; } = new List<workorderrouting>();
}