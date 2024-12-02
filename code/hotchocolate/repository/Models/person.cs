﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.
/// </summary>
[Table("person", Schema = "person")]
public partial class person
{
    /// <summary>
    /// Primary key for Person records.
    /// </summary>
    [Key]
    public int businessentityid { get; set; }

    /// <summary>
    /// Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact
    /// </summary>
    [Required]
    [StringLength(2)]
    public string persontype { get; set; }

    /// <summary>
    /// 0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.
    /// </summary>
    public bool namestyle { get; set; }

    /// <summary>
    /// A courtesy title. For example, Mr. or Ms.
    /// </summary>
    [StringLength(8)]
    public string title { get; set; }

    /// <summary>
    /// First name of the person.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string firstname { get; set; }

    /// <summary>
    /// Middle name or middle initial of the person.
    /// </summary>
    [StringLength(50)]
    public string middlename { get; set; }

    /// <summary>
    /// Last name of the person.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string lastname { get; set; }

    /// <summary>
    /// Surname suffix. For example, Sr. or Jr.
    /// </summary>
    [StringLength(10)]
    public string suffix { get; set; }

    /// <summary>
    /// 0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners.
    /// </summary>
    public int emailpromotion { get; set; }

    /// <summary>
    /// Additional contact information about the person stored in xml format.
    /// </summary>
    [Column(TypeName = "xml")]
    public string additionalcontactinfo { get; set; }

    /// <summary>
    /// Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.
    /// </summary>
    [Column(TypeName = "xml")]
    public string demographics { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("businessentityid")]
    [InverseProperty("person")]
    public virtual businessentity businessentity { get; set; }

    [InverseProperty("person")]
    public virtual ICollection<businessentitycontact> businessentitycontacts { get; set; } = new List<businessentitycontact>();

    [InverseProperty("person")]
    public virtual ICollection<customer> customers { get; set; } = new List<customer>();

    [InverseProperty("businessentity")]
    public virtual ICollection<emailaddress> emailaddresses { get; set; } = new List<emailaddress>();

    [InverseProperty("businessentity")]
    public virtual employee employee { get; set; }

    [InverseProperty("businessentity")]
    public virtual password password { get; set; }

    [InverseProperty("businessentity")]
    public virtual ICollection<personcreditcard> personcreditcards { get; set; } = new List<personcreditcard>();

    [InverseProperty("businessentity")]
    public virtual ICollection<personphone> personphones { get; set; } = new List<personphone>();
}