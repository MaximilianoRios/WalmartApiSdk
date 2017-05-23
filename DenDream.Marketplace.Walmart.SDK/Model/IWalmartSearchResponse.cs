using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    /// <summary>
    /// Data contract to implement abstracting from the format implementation (Json/Xml)
    /// </summary>
    public interface IWalmartSearchResponse
    {
        string Query { get; set; }
        string Sort { get; set; }
        string ResponseGroup { get; set; }
        int TotalResults { get; set; }
        int Start { get; set; }
        int NumItems { get; set; }

        /// <summary>
        /// Abstraction that both have to implement to be able to access exactly in the same way
        /// </summary>
        IEnumerable<IWalmartSearchItem> Items { get; }
    }

    public interface IWalmartSearchItem
    {
        int Id { get; set; }
        int ParentId { get; set; }
        string Name { get; set; }
        decimal Msrp { get; set; }
        decimal SalePrice { get; set; }
        string Upc { get; set; }
        string CategoryPath { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string ThumbnailImage { get; set; }
        string MediumImage { get; set; }
        string LargeImage { get; set; }
        string ProductTrackingUrl { get; set; }
        decimal StandardShipRate { get; set; }
        bool Marketplace { get; set; }
        string ModelNumber { get; set; }
        string SellerInfo { get; set; }
        string ProductUrl { get; set; }
        decimal CustomerRating { get; set; }
        int NumReviews { get; set; }
        string CustomerRatingImage { get; set; }
        string CategoryNode { get; set; }
        bool Bundle { get; set; }
        string Stock { get; set; }
        string AddToCartUrl { get; set; }
        string AffiliateAddToCartUrl { get; set; }
        bool AvailableOnline { get; set; }
        /// <summary>
        /// Abstraction that both have to implement to be able to access exactly in the same way
        /// </summary>
        IGiftOptions GiftOptions { get; set; }
        /// <summary>
        /// Abstraction that both have to implement to be able to access exactly in the same way
        /// </summary>
        IEnumerable<IImageEntity> ImageEntities { get; set; }
        string OfferType { get; set; }
        bool IsTwoDayShippingEligible { get; set; }
    }

    public interface IGiftOptions
    {
        bool AllowGiftWrap { get; set; }
        bool AllowGiftMessage { get; set; }
        bool AllowGiftReceipt { get; set; }
    }

    public interface IImageEntity
    {
        string ThumbnailImage { get; set; }
        string MediumImage { get; set; }
        string LargeImage { get; set; }
        string EntityType { get; set; }
    }

}
