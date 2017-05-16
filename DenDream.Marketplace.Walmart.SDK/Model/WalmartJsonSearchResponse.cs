using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    /// <summary>
    /// The XML serialization model differs from the JSON model, in that case it's necessary to deserialize
    /// and convert to a common model in two steps
    /// </summary>
    public class WalmartJsonSearchResponse : WalmartSearchBaseResponse
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("responseGroup")]
        public string ResponseGroup { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("numItems")]
        public int NumItems { get; set; }

        //[JsonProperty("facets")]
        //[JsonProperty("facets")]
        //public string Facets { get; set; }

        [JsonProperty("items")]
        public List<WalmartJsonSearchItem> Items { get; set; }

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
            if (this.Items != null)
            {
                response.Items = new List<WalmartSearchItem>();
                foreach (var item in this.Items)
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
                    if (item.GiftOptions != null)
                    {
                        newItem.GiftOptions = new GiftOption()
                        {
                            AllowGiftMessage = item.GiftOptions.AllowGiftMessage,
                            AllowGiftReceipt = item.GiftOptions.AllowGiftReceipt,
                            AllowGiftWrap = item.GiftOptions.AllowGiftWrap
                        };
                    }
                    if(item.ImageEntities != null)
                    {
                        newItem.ImageEntities = new List<ImageEntity>();
                        foreach (var imageEntity in item.ImageEntities)
                        {
                            newItem.ImageEntities.Add(new ImageEntity()
                            {
                                EntityType = imageEntity.EntityType,
                                ThumbnailImage = imageEntity.ThumbnailImage,
                                LargeImage = imageEntity.LargeImage,
                                MediumImage = imageEntity.MediumImage
                            });
                        }
                    }
                    response.Items.Add(newItem);
                }
            }
            return response;
        }
    }

    public class WalmartJsonSearchItem
    {
        [JsonProperty("itemId")]
        public int Id { get; set; }

        [JsonProperty("parentItemId")]
        public int ParentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("msrp")]
        public decimal Msrp { get; set; }

        [JsonProperty("salePrice")]
        public decimal SalePrice { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("categoryPath")]
        public string CategoryPath { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        [JsonProperty("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [JsonProperty("mediumImage")]
        public string MediumImage { get; set; }

        [JsonProperty("largeImage")]
        public string LargeImage { get; set; }

        [JsonProperty("productTrackingUrl")]
        public string ProductTrackingUrl { get; set; }

        [JsonProperty("standardShipRate")]
        public decimal StandardShipRate { get; set; }

        [JsonProperty("marketplace")]
        public bool Marketplace { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("productUrl")]
        public string ProductUrl { get; set; }

        [JsonProperty("customerRating")]
        public decimal CustomerRating { get; set; }

        [JsonProperty("numReviews")]
        public int NumReviews { get; set; }

        [JsonProperty("customerRatingImage")]
        public string CustomerRatingImage { get; set; }

        [JsonProperty("categoryNode")]
        public string CategoryNode { get; set; }

        [JsonProperty("bundle")]
        public bool Bundle { get; set; }

        [JsonProperty("stock")]
        public string Stock { get; set; }

        [JsonProperty("addToCartUrl")]
        public string AddToCartUrl { get; set; }

        [JsonProperty("affiliateAddToCartUrl")]
        public string AffiliateAddToCartUrl { get; set; }

        [JsonProperty("availableOnline")]
        public bool AvailableOnline { get; set; }

        [JsonProperty("giftOptions")]
        public JsonGiftOption GiftOptions { get; set; }

        [JsonProperty("imageEntities")]
        public List<JsonImageEntity> ImageEntities { get; set; }

        [JsonProperty("offerType")]
        public string OfferType { get; set; }

        [JsonProperty("isTwoDayShippingEligible")]
        public bool IsTwoDayShippingEligible { get; set; }
    }

    public class JsonGiftOption
    {
        [JsonProperty("allowGiftWrap")]
        public bool AllowGiftWrap { get; set; }

        [JsonProperty("allowGiftMessage")]
        public bool AllowGiftMessage { get; set; }

        [JsonProperty("allowGiftReceipt")]
        public bool AllowGiftReceipt { get; set; }
    }

    public class JsonImageEntity
    {
        [JsonProperty("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [JsonProperty("mediumImage")]
        public string MediumImage { get; set; }

        [JsonProperty("largeImage")]
        public string LargeImage { get; set; }

        [JsonProperty("entityType")]
        public string EntityType { get; set; }
    }
}
