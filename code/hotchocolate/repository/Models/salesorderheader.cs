﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// General sales order information.
/// </summary>
[Table("salesorderheader", Schema = "sales")]
public partial class salesorderheader
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    public int salesorderid { get; set; }

    /// <summary>
    /// Incremental number to track changes to the sales order over time.
    /// </summary>
    public short revisionnumber { get; set; }

    /// <summary>
    /// Dates the sales order was created.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime orderdate { get; set; }

    /// <summary>
    /// Date the order is due to the customer.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime duedate { get; set; }

    /// <summary>
    /// Date the order was shipped to the customer.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? shipdate { get; set; }

    /// <summary>
    /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
    /// </summary>
    public short status { get; set; }

    /// <summary>
    /// 0 = Order placed by sales person. 1 = Order placed online by customer.
    /// </summary>
    public bool onlineorderflag { get; set; }

    /// <summary>
    /// Customer purchase order number reference.
    /// </summary>
    [StringLength(25)]
    public string purchaseordernumber { get; set; }

    /// <summary>
    /// Financial accounting number reference.
    /// </summary>
    [StringLength(15)]
    public string accountnumber { get; set; }

    /// <summary>
    /// Customer identification number. Foreign key to Customer.BusinessEntityID.
    /// </summary>
    public int customerid { get; set; }

    /// <summary>
    /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    public int? salespersonid { get; set; }

    /// <summary>
    /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    public int? territoryid { get; set; }

    /// <summary>
    /// Customer billing address. Foreign key to Address.AddressID.
    /// </summary>
    public int billtoaddressid { get; set; }

    /// <summary>
    /// Customer shipping address. Foreign key to Address.AddressID.
    /// </summary>
    public int shiptoaddressid { get; set; }

    /// <summary>
    /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
    /// </summary>
    public int shipmethodid { get; set; }

    /// <summary>
    /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
    /// </summary>
    public int? creditcardid { get; set; }

    /// <summary>
    /// Approval code provided by the credit card company.
    /// </summary>
    [StringLength(15)]
    public string creditcardapprovalcode { get; set; }

    /// <summary>
    /// Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.
    /// </summary>
    public int? currencyrateid { get; set; }

    /// <summary>
    /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
    /// </summary>
    public decimal subtotal { get; set; }

    /// <summary>
    /// Tax amount.
    /// </summary>
    public decimal taxamt { get; set; }

    /// <summary>
    /// Shipping cost.
    /// </summary>
    public decimal freight { get; set; }

    /// <summary>
    /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
    /// </summary>
    public decimal? totaldue { get; set; }

    /// <summary>
    /// Sales representative comments.
    /// </summary>
    [StringLength(128)]
    public string comment { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [ForeignKey("billtoaddressid")]
    [InverseProperty("salesorderheaderbilltoaddresses")]
    public virtual address billtoaddress { get; set; }

    [ForeignKey("creditcardid")]
    [InverseProperty("salesorderheaders")]
    public virtual creditcard creditcard { get; set; }

    [ForeignKey("currencyrateid")]
    [InverseProperty("salesorderheaders")]
    public virtual currencyrate currencyrate { get; set; }

    [ForeignKey("customerid")]
    [InverseProperty("salesorderheaders")]
    public virtual customer customer { get; set; }

    [InverseProperty("salesorder")]
    public virtual ICollection<salesorderdetail> salesorderdetails { get; set; } = new List<salesorderdetail>();

    [InverseProperty("salesorder")]
    public virtual ICollection<salesorderheadersalesreason> salesorderheadersalesreasons { get; set; } = new List<salesorderheadersalesreason>();

    [ForeignKey("salespersonid")]
    [InverseProperty("salesorderheaders")]
    public virtual salesperson salesperson { get; set; }

    [ForeignKey("shipmethodid")]
    [InverseProperty("salesorderheaders")]
    public virtual shipmethod shipmethod { get; set; }

    [ForeignKey("shiptoaddressid")]
    [InverseProperty("salesorderheadershiptoaddresses")]
    public virtual address shiptoaddress { get; set; }

    [ForeignKey("territoryid")]
    [InverseProperty("salesorderheaders")]
    public virtual salesterritory territory { get; set; }
}