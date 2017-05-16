using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// The XML serialization model differs from the JSON model, in that case it's necessary to deserialize
/// and convert to a common model in two steps
/// </summary>
namespace DenDream.Marketplace.Walmart.SDK.Model
{
    [XmlRoot("searchresponse")]
    public class WalmartXmlSearchResponse : WalmartSearchBaseResponse
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

        //[JsonProperty("facets")]
        //[XmlElement("facets")]
        //public string Facets { get; set; }

        [XmlElement("items")]
        public WalmartXmlSearchItems Result { get; set; }

        public override WalmartSearchResponse GetResponse()
        {
            var response = new WalmartSearchResponse()
            {
                Query = this.Query,
                Sort = this.Sort,
                ResponseGroup = this.ResponseGroup,
                TotalResults = this.TotalResults,
                Start = this.Start,
                NumItems = this.NumItems,
            };
            if (this.Result.Items != null)
            {
                response.Items = new List<WalmartSearchItem>();
                foreach (var item in this.Result.Items)
                {
                    var newItem = new WalmartSearchItem()
                    {
                        Id = item.Id,
                        ParentId = item.ParentId,
                        Name = item.Name,
                        Msrp = item.Msrp,
                        SalePrice = item.SalePrice,
                        Upc = item.Upc,
                        CategoryPath = item.CategoryPath,
                        ShortDescription = item.ShortDescription,
                        LongDescription = item.LongDescription,
                        ThumbnailImage = item.ThumbnailImage,
                        MediumImage = item.MediumImage,
                        LargeImage = item.LargeImage,
                        ProductTrackingUrl = item.ProductTrackingUrl,
                        StandardShipRate = item.StandardShipRate,
                        Marketplace = item.Marketplace,
                        ModelNumber = item.ModelNumber,
                        ProductUrl = item.ProductUrl,
                        CustomerRating = item.CustomerRating,
                        NumReviews = item.NumReviews,
                        CustomerRatingImage = item.CustomerRatingImage,
                        CategoryNode = item.CategoryNode,
                        Bundle = item.Bundle,
                        Stock = item.Stock,
                        AddToCartUrl = item.AddToCartUrl,
                        AffiliateAddToCartUrl = item.AffiliateAddToCartUrl,
                        AvailableOnline = item.AvailableOnline,
                        OfferType = item.OfferType,
                        IsTwoDayShippingEligible = item.IsTwoDayShippingEligible
                    };
                    if (item.GiftOptions != null && item.GiftOptions.Count > 0)
                    {
                        newItem.GiftOptions = new GiftOption()
                        {
                            AllowGiftMessage = item.GiftOptions[0].AllowGiftMessage,
                            AllowGiftReceipt = item.GiftOptions[0].AllowGiftReceipt,
                            AllowGiftWrap = item.GiftOptions[0].AllowGiftWrap
                        };
                    }
                    if (item.ImageEntities != null)
                    {
                        newItem.ImageEntities = new List<ImageEntity>();
                        foreach (var imageEntity in item.ImageEntities.Images)
                        {
                            newItem.ImageEntities.Add(new ImageEntity()
                            {
                                EntityType = imageEntity.EntityType,
                                ThumbnailImage = imageEntity.ThumbnailImage,
                                LargeImage = imageEntity.LargeImage,
                                MediumImage = imageEntity.MediumImage
                            });
                            response.Items.Add(newItem);
                        }
                    }
                }
            }
            return response;
        }
    }

    public class WalmartXmlSearchItems
    {
        [XmlElement("item")]
        public List<WalmartXmlSearchItem> Items { get; set; }
    }

    public class WalmartXmlSearchItem
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
        public List<XmlGiftOption> GiftOptions { get; set; }

        [XmlElement("imageEntities")] 
        public XmlImageEntities ImageEntities { get; set; }

        [XmlElement("offerType")]
        public string OfferType { get; set; }

        [XmlElement("isTwoDayShippingEligible")]
        public bool IsTwoDayShippingEligible { get; set; }
    }

    public class XmlGiftOption
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

    public class XmlImageEntity
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
