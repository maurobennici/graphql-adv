﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace repository.Models;

/// <summary>
/// Products sold or used in the manfacturing of sold products.
/// </summary>
[Table("product", Schema = "production")]
public partial class product
{
    /// <summary>
    /// Primary key for Product records.
    /// </summary>
    [Key]
    public int productid { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    /// <summary>
    /// Unique product identification number.
    /// </summary>
    [Required]
    [StringLength(25)]
    public string productnumber { get; set; }

    /// <summary>
    /// 0 = Product is purchased, 1 = Product is manufactured in-house.
    /// </summary>
    public bool makeflag { get; set; }

    /// <summary>
    /// 0 = Product is not a salable item. 1 = Product is salable.
    /// </summary>
    public bool finishedgoodsflag { get; set; }

    /// <summary>
    /// Product color.
    /// </summary>
    [StringLength(15)]
    public string color { get; set; }

    /// <summary>
    /// Minimum inventory quantity.
    /// </summary>
    public short safetystocklevel { get; set; }

    /// <summary>
    /// Inventory level that triggers a purchase order or work order.
    /// </summary>
    public short reorderpoint { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    public decimal standardcost { get; set; }

    /// <summary>
    /// Selling price.
    /// </summary>
    public decimal listprice { get; set; }

    /// <summary>
    /// Product size.
    /// </summary>
    [StringLength(5)]
    public string size { get; set; }

    /// <summary>
    /// Unit of measure for Size column.
    /// </summary>
    [StringLength(3)]
    public string sizeunitmeasurecode { get; set; }

    /// <summary>
    /// Unit of measure for Weight column.
    /// </summary>
    [StringLength(3)]
    public string weightunitmeasurecode { get; set; }

    /// <summary>
    /// Product weight.
    /// </summary>
    [Precision(8, 2)]
    public decimal? weight { get; set; }

    /// <summary>
    /// Number of days required to manufacture the product.
    /// </summary>
    public int daystomanufacture { get; set; }

    /// <summary>
    /// R = Road, M = Mountain, T = Touring, S = Standard
    /// </summary>
    [StringLength(2)]
    public string productline { get; set; }

    /// <summary>
    /// H = High, M = Medium, L = Low
    /// </summary>
    [Column("class")]
    [StringLength(2)]
    public string _class { get; set; }

    /// <summary>
    /// W = Womens, M = Mens, U = Universal
    /// </summary>
    [StringLength(2)]
    public string style { get; set; }

    /// <summary>
    /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID.
    /// </summary>
    public int? productsubcategoryid { get; set; }

    /// <summary>
    /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    public int? productmodelid { get; set; }

    /// <summary>
    /// Date the product was available for sale.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime sellstartdate { get; set; }

    /// <summary>
    /// Date the product was no longer available for sale.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? sellenddate { get; set; }

    /// <summary>
    /// Date the product was discontinued.
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? discontinueddate { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime modifieddate { get; set; }

    [InverseProperty("component")]
    public virtual ICollection<billofmaterial> billofmaterialcomponents { get; set; } = new List<billofmaterial>();

    [InverseProperty("productassembly")]
    public virtual ICollection<billofmaterial> billofmaterialproductassemblies { get; set; } = new List<billofmaterial>();

    [InverseProperty("product")]
    public virtual ICollection<productcosthistory> productcosthistories { get; set; } = new List<productcosthistory>();

    [InverseProperty("product")]
    public virtual ICollection<productdocument> productdocuments { get; set; } = new List<productdocument>();

    [InverseProperty("product")]
    public virtual ICollection<productinventory> productinventories { get; set; } = new List<productinventory>();

    [InverseProperty("product")]
    public virtual ICollection<productlistpricehistory> productlistpricehistories { get; set; } = new List<productlistpricehistory>();

    [ForeignKey("productmodelid")]
    [InverseProperty("products")]
    public virtual productmodel productmodel { get; set; }

    [InverseProperty("product")]
    public virtual ICollection<productproductphoto> productproductphotos { get; set; } = new List<productproductphoto>();

    [InverseProperty("product")]
    public virtual ICollection<productreview> productreviews { get; set; } = new List<productreview>();

    [ForeignKey("productsubcategoryid")]
    [InverseProperty("products")]
    public virtual productsubcategory productsubcategory { get; set; }

    [InverseProperty("product")]
    public virtual ICollection<productvendor> productvendors { get; set; } = new List<productvendor>();

    [InverseProperty("product")]
    public virtual ICollection<purchaseorderdetail> purchaseorderdetails { get; set; } = new List<purchaseorderdetail>();

    [InverseProperty("product")]
    public virtual ICollection<shoppingcartitem> shoppingcartitems { get; set; } = new List<shoppingcartitem>();

    [ForeignKey("sizeunitmeasurecode")]
    [InverseProperty("productsizeunitmeasurecodeNavigations")]
    public virtual unitmeasure sizeunitmeasurecodeNavigation { get; set; }

    [InverseProperty("product")]
    public virtual ICollection<specialofferproduct> specialofferproducts { get; set; } = new List<specialofferproduct>();

    [InverseProperty("product")]
    public virtual ICollection<transactionhistory> transactionhistories { get; set; } = new List<transactionhistory>();

    [ForeignKey("weightunitmeasurecode")]
    [InverseProperty("productweightunitmeasurecodeNavigations")]
    public virtual unitmeasure weightunitmeasurecodeNavigation { get; set; }

    [InverseProperty("product")]
    public virtual ICollection<workorder> workorders { get; set; } = new List<workorder>();
}