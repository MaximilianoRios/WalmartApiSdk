using System;
using System.Collections.Generic;
using System.Xml.Serialization;

/// <summary>
/// The XML serialization model differs from the JSON model, in that case it's necessary to deserialize
/// and convert to a common model in two steps
/// </summary>
namespace DenDream.Marketplace.Walmart.SDK.Model.Xml
{
    [XmlRoot("searchresponse")]
    public class WalmartXmlSearchResponse : IWalmartSearchResponse
    {
        [XmlElement("query")]
        public string Query { get; set; }

        [XmlElement("sort")]
        public string Sort { get; set; }

        [XmlElement("responseGroup")]
        public string ResponseGroup { get; set; }

        [XmlElement("totalResults")]
        public int TotalResults { get; set; }

        [XmlElement("start")]
        public int Start { get; set; }

        [XmlElement("numItems")]
        public int NumItems { get; set; }

        [XmlElement("items")]
        public WalmartXmlSearchItems Result { get; set; }

        [XmlIgnore]
        public IEnumerable<IWalmartSearchItem> Items
        {
            get
            {
                // Proxy the result
                if(Result != null)
                {
                    return Result.Items;
                }
                return null;
            }
        }
    }

    public class WalmartXmlSearchItems
    {
        [XmlElement("item")]
        public List<WalmartXmlSearchItem> Items { get; set; }
    }

    public class WalmartXmlSearchItem : IWalmartSearchItem
    {
        [XmlElement("itemId")]
        public int Id { get; set; }

        [XmlElement("parentItemId")]
        public int ParentId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("msrp")]
        public decimal Msrp { get; set; }

        [XmlElement("salePrice")]
        public decimal SalePrice { get; set; }

        [XmlElement("upc")]
        public string Upc { get; set; }

        [XmlElement("categoryPath")]
        public string CategoryPath { get; set; }

        [XmlElement("shortDescription")]
        public string ShortDescription { get; set; }

        [XmlElement("longDescription")]
        public string LongDescription { get; set; }

        [XmlElement("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [XmlElement("mediumImage")]
        public string MediumImage { get; set; }

        [XmlElement("largeImage")]
        public string LargeImage { get; set; }

        [XmlElement("productTrackingUrl")]
        public string ProductTrackingUrl { get; set; }

        [XmlElement("standardShipRate")]
        public decimal StandardShipRate { get; set; }

        [XmlElement("marketplace")]
        public bool Marketplace { get; set; }

        [XmlElement("modelNumber")]
        public string ModelNumber { get; set; }

        [XmlElement("sellerInfo")]
        public string SellerInfo { get; set; }

        [XmlElement("productUrl")]
        public string ProductUrl { get; set; }

        [XmlElement("customerRating")]
        public decimal CustomerRating { get; set; }

        [XmlElement("numReviews")]
        public int NumReviews { get; set; }

        [XmlElement("customerRatingImage")]
        public string CustomerRatingImage { get; set; }

        [XmlElement("categoryNode")]
        public string CategoryNode { get; set; }

        [XmlElement("bundle")]
        public bool Bundle { get; set; }

        [XmlElement("stock")]
        public string Stock { get; set; }

        [XmlElement("addToCartUrl")]
        public string AddToCartUrl { get; set; }

        [XmlElement("affiliateAddToCartUrl")]
        public string AffiliateAddToCartUrl { get; set; }

        [XmlElement("availableOnline")]
        public bool AvailableOnline { get; set; }

        [XmlElement("giftOptions")]
        public List<XmlGiftOption> XmlGiftOptions { get; set; }

        [XmlElement("imageEntities")] 
        public XmlImageEntities XmlImageEntities { get; set; }

        [XmlElement("offerType")]
        public string OfferType { get; set; }

        [XmlElement("isTwoDayShippingEligible")]
        public bool IsTwoDayShippingEligible { get; set; }

        // Proxies to the data
        [XmlIgnore]
        public IGiftOptions GiftOptions
        {
            get
            {
                if(XmlGiftOptions != null && XmlGiftOptions.Count> 0)
                {
                    return XmlGiftOptions[0];
                }
                return null;
            }

            set
            {
                // No set for now
            }
        }

        [XmlIgnore]
        public IEnumerable<IImageEntity> ImageEntities
        {
            get
            {
                if(XmlImageEntities != null)
                {
                    return XmlImageEntities.Images;
                }
                return null;
            }

            set
            {
                // No set for now
            }
        }
    }

    public class XmlGiftOption : IGiftOptions
    {
        [XmlElement("allowGiftWrap")]
        public bool AllowGiftWrap { get; set; }

        [XmlElement("allowGiftMessage")]
        public bool AllowGiftMessage { get; set; }

        [XmlElement("allowGiftReceipt")]
        public bool AllowGiftReceipt { get; set; }
    }

    public class XmlImageEntities 
    {
        [XmlElement("imageEntities")]
        public List<XmlImageEntity> Images {get; set; }
    }

    public class XmlImageEntity : IImageEntity
    {
        [XmlElement("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [XmlElement("mediumImage")]
        public string MediumImage { get; set; }

        [XmlElement("largeImage")]
        public string LargeImage { get; set; }

        [XmlElement("entityType")]
        public string EntityType { get; set; }
    }
}
