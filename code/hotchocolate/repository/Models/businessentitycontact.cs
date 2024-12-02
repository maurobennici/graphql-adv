﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Cross-reference table mapping stores, vendors, and employees to people
/// </summary>
[PrimaryKey("businessentityid", "personid", "contacttypeid")]
[Table("businessentitycontact", Schema = "person")]
public partial class businessentitycontact
{
    /// <summary>
    /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Person.BusinessEntityID.
    /// </summary>
    [Key]
    public int personid { get; set; }

    /// <summary>
    /// Primary key.  Foreign key to ContactType.ContactTypeID.
    /// </summary>
    [Key]
    public int contacttypeid { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("businessentitycontacts")]
    public virtual businessentity businessentity { get; set; }

    [ForeignKey("contacttypeid")]
    [InverseProperty("businessentitycontacts")]
    public virtual contacttype contacttype { get; set; }

    [ForeignKey("personid")]
    [InverseProperty("businessentitycontacts")]
    public virtual person person { get; set; }
}