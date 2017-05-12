using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    [XmlRoot("searchresponse")]
    public class WalmartSearchResponse
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
        [XmlElement("facets")]
        public string Facets { get; set; }

        [XmlElement("items")]
        public WalmartSearchItems Result { get; set; }
    }

    public class WalmartSearchItems
    {
        [XmlElement("item")]
        public List<WalmartSearchItem> Items { get; set; }
    }

    public class WalmartSearchItem
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
        public List<GiftOption> GiftOptions { get; set; }

        [XmlElement("imageEntities")] 
        public ImageEntities ImageEntities { get; set; }

        [XmlElement("offerType")]
        public string OfferType { get; set; }

        [XmlElement("isTwoDayShippingEligible")]
        public bool IsTwoDayShippingEligible { get; set; }
    }

    public class GiftOption
    {
        [XmlElement("allowGiftWrap")]
        public bool AllowGiftWrap { get; set; }

        [XmlElement("allowGiftMessage")]
        public bool AllowGiftMessage { get; set; }

        [XmlElement("allowGiftReceipt")]
        public bool AllowGiftReceipt { get; set; }
    }

    public class ImageEntities
    {
        [XmlElement("imageEntities")]
        public List<ImageEntity> Images {get; set; }
    }

    public class ImageEntity
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
