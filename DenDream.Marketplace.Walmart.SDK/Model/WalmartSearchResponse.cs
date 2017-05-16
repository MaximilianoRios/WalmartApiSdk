using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    /// <summary>
    /// Class that holds the common parameters between XML and JSON. Deserialization is very different
    /// between them and it requires an intermmediate abstraction
    /// </summary>
    public class WalmartSearchResponse
    {
        public string Query { get; set; }

        public string Sort { get; set; }

        public string ResponseGroup { get; set; }

        public int TotalResults { get; set; }

        public int Start { get; set; }

        public int NumItems { get; set; }

        public string[] Facets { get; set; }

        public List<WalmartSearchItem> Items { get; set; }

    }

    public class WalmartSearchItem
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public decimal Msrp { get; set; }

        public decimal SalePrice { get; set; }

        public string Upc { get; set; }

        public string CategoryPath { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ThumbnailImage { get; set; }

        public string MediumImage { get; set; }

        public string LargeImage { get; set; }

        public string ProductTrackingUrl { get; set; }

        public decimal StandardShipRate { get; set; }

        public bool Marketplace { get; set; }

        public string ModelNumber { get; set; }

        public string ProductUrl { get; set; }

        public decimal CustomerRating { get; set; }

        public int NumReviews { get; set; }

        public string CustomerRatingImage { get; set; }

        public string CategoryNode { get; set; }

        public bool Bundle { get; set; }

        public string Stock { get; set; }

        public string AddToCartUrl { get; set; }

        public string AffiliateAddToCartUrl { get; set; }

        public bool AvailableOnline { get; set; }

        public GiftOption GiftOptions { get; set; }

        public List<ImageEntity> ImageEntities { get; set; }

        public string OfferType { get; set; }

        public bool IsTwoDayShippingEligible { get; set; }
    }

    public class GiftOption
    {
        public bool AllowGiftWrap { get; set; }

        public bool AllowGiftMessage { get; set; }

        public bool AllowGiftReceipt { get; set; }
    }

    public class ImageEntity
    {
        public string ThumbnailImage { get; set; }

        public string MediumImage { get; set; }

        public string LargeImage { get; set; }

        public string EntityType { get; set; }
    }
}
