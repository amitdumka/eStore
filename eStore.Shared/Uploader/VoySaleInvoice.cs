﻿using System;
using System.ComponentModel.DataAnnotations;

namespace eStore.Shared.Uploader
{
    //SaleInvoice Details
    //Invoice No	Invoice Date	Invoice Type	Brand Name	Product Name	Item Desc	HSN Code	BAR CODE	Style Code	Quantity	MRP	Discount Amt	Basic Amt	Tax Amt	SGST Amt	CGST Amt	CESS Amt	Line Total	Round Off	Bill Amt	Payment Mode	SalesMan Name	Coupon %	Coupon Amt	SUB TYPE	Bill Discount	LP Flag	Inst Order CD	TAILORING FLAG

    public class VoySaleInvoice
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ItemDesc { get; set; }
        public string HSNCode { get; set; }
        public string BARCODE { get; set; }
        public string StyleCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal BasicAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal SGSTAmt { get; set; }
        public decimal CGSTAmt { get; set; }
        public decimal CESSAmt { get; set; }
        public decimal LineTotal { get; set; }
        public decimal RoundOff { get; set; }
        public decimal BillAmt { get; set; }
        public string PaymentMode { get; set; }
        public string SalesManName { get; set; }
        public string Coupon { get; set; }
        public string CouponAmt { get; set; }
        public string SUBTYPE { get; set; }
        public string BillDiscount { get; set; }
        public string LPFlag { get; set; }
        public string InstOrderCD { get; set; }
        public string TailoringFlag { get; set; }
    }

    //SaleInv Summy
    //Invoice No	Invoice Date	Invoice Type	Quantity	MRP	Discount Amt	Basic Amt	Tax Amt	Round Off	Bill Amt	Payment Type	Coupon %	Coupon Amt	LP Flag	Inst Order CD	Tailoring Flag
    public class VoySaleInvoiceSum
    {
        //Invoice No	Invoice Date	Invoice Type	Quantity	MRP	Discount Amt	Basic Amt	Tax Amt	Round Off	Bill Amt	Payment Type
        //Coupon %	Coupon Amt	LP Flag	Inst Order CD	Tailoring Flag
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public decimal Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal BasicAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal RoundOff { get; set; }
        public decimal BillAmt { get; set; }
        public string PaymentMode { get; set; }
        public string Coupon { get; set; }
        public string CouponAmt { get; set; }
        public string LPFlag { get; set; }
        public string InstOrderCD { get; set; }
        public string TailoringFlag { get; set; }
    }

    //Purhcase Inward
    //GRNNo GRNDate Invoice No  Invoice Date    Supplier Name   Barcode Product Name Style Code Item Desc Quantity    MRP MRP Value Cost    Cost Value  TaxAmt ExmillCost  Excise1 Excise2 Excise3
    public class VoyPurchaseInward
    {
        public int ID { get; set; }
        public string GRNNo { get; set; }
        public DateTime GRNDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string StyleCode { get; set; }
        public string ItemDesc { get; set; }
        public decimal Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal MRPValue { get; set; }
        public decimal Cost { get; set; }
        public decimal CostValue { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal ExmillCost { get; set; }
        public decimal Excise1 { get; set; }
        public decimal Excise2 { get; set; }
        public decimal Excise3 { get; set; }
    }

    //PurcaseInwardSummy
    //Inward No	Inward Date	Invoice No	Invoice Date	Party Name	Total Qty	Total MRP Value	Total Cost

    public class InwardSummary
    {
        public int ID { get; set; }
        public string InwardNo { get; set; }
        public DateTime InwardDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PartyName { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalMRPValue { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class VoyBrandName
    {
        [Key]
        public int ID { get; set; }
        public string BRANDCODE { get; set; }
        public string BRANDNAME { get; set; }
    }

    //BRANDCODE BRANDNAME
    //ADR Arvind Ready Wear
    //AGV Arvind GV
    //ANK Ankur Fabrics
    //ARA Arvind Accessories
    //ARD Arvind
    //ARI Arvind
    //ARN Arrow New York
    //ARP Arvind Promo
    //ARR Arrow
    //ARS Arrow Sports
    //ARV Arvind Store
    //ASW Arvind Swatch
    //FM  Flying Machine
    //HAN Hanes International
    //IZ  Izod
    //NAT Nautica
    //SAR Studio Arvind
    //SAT Studio Arvind Tailored
    //THF Tommy Hilfiger
    //UD  US DENIM & Co
    //USP US Polo Association

    public class ProductList
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string BrandCode { get; set; }
        public string ProductCode { get; set; }
        public string UOM { get; set; }
        public string TaxCode { get; set; }
        public string TaxType { get; set; }
        public decimal Price { get; set; }
        public string PRINCIPAL_FCD { get; set; }
    }

    public class ProductMaster
    {
        public int Id { get; set; }
        public string PRODUCTCODE { get; set; }
        public string PRODUCTNAME { get; set; }
    }

    //Invoice No	Invoice Date	Invoice Type	Brand Name	Product Name	Item Desc	BARCODE	Style Code	Quantity	Sale Value	Discount Amt	Basic Amt	Tax Amt	Tax Rate	Tax Desc	Bill Amt

    public class TaxRegister
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ItemDesc { get; set; }
        public string BARCODE { get; set; }
        public string StyleCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal SaleValue { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal BasicAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxDesc { get; set; }
        public decimal BillAmt { get; set; }
    }

    //Invoice No	Invoice Date	Invoice Type	Quantity	Bill Amt	Payment Type	Customer Name	Address	Phone	Email	Date of Birth

    public class SaleWithCustomer
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public decimal Quantity { get; set; }
        public decimal BillAmt { get; set; }
        public string PaymentType { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DateofBirth { get; set; }
    }
}