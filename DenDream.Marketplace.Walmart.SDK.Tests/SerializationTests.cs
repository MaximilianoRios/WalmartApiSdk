using DenDream.Marketplace.Walmart.SDK;
using DenDream.Marketplace.Walmart.SDK.Converters;
using DenDream.Marketplace.Walmart.SDK.Model;
using DenDream.Marketplace.Walmart.SDK.Model.Json;
using DenDream.Marketplace.Walmart.SDK.Model.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Tests
{
    [TestClass]
    public class SerializationTests
    {
        private string _searchResponseSampleXml;
        private string _searchResponseSampleJson;

        [TestInitialize]
        public void SetUp()
        {
            // It's not a good practice to depend on the file system but it's easier to write big files within it
            using (StreamReader reader = new StreamReader("SearchResponseSample.xml"))
            {
                _searchResponseSampleXml = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader("SearchResponseSample.json"))
            {
                _searchResponseSampleJson = reader.ReadToEnd();
            }
        }

        [TestMethod]
        public void SearchResultSerializationJson_ValidResponse_AgnosticModelFilled()
        {
            var converter = ConverterFactory.GetConverter(WalmartResponseFormat.Json);
            var responseModel = converter.Convert<WalmartJsonSearchResponse>(_searchResponseSampleJson) as IWalmartSearchResponse;

           // The model can be treated always as a IWalmartSearchResponse

            // Several asserts to evaluate response correctness
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Query), "query cannot be null");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.ResponseGroup), "response group cannot be null");
            Assert.IsTrue(responseModel.NumItems > 0, "Items must be greater than zero");
            Assert.IsTrue(responseModel.TotalResults > 0, "Total results must be greater than zero");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Sort), "sort cannot be null");

            var itemCount = responseModel.Items.Count();
            Assert.IsTrue(itemCount > 0, "No items found");

            // Assert on individual items
            var itemsFound = 0;
            foreach (var item in responseModel.Items)
            {
                Assert.IsTrue(item.Id > 0, "Incorrect item id");
                Assert.IsTrue(item.Id > 0, "Incorrect parent id");
                Assert.IsTrue(!string.IsNullOrEmpty(item.Name), "Incorrect name");
                Assert.IsTrue(item.SalePrice > 0, "Incorrect sales price");
                Assert.IsTrue(!string.IsNullOrEmpty(item.Upc), "Incorrect UPC");
                Assert.IsTrue(!string.IsNullOrEmpty(item.CategoryPath), "Incorrect category path");
                Assert.IsTrue(!string.IsNullOrEmpty(item.LongDescription), "Incorrect long description");
                Assert.IsTrue(!string.IsNullOrEmpty(item.ThumbnailImage), "Incorrect thumbnail image");
                Assert.IsTrue(!string.IsNullOrEmpty(item.MediumImage), "Incorrect medium image");
                Assert.IsTrue(!string.IsNullOrEmpty(item.LargeImage), "Incorrect large image");
                Assert.IsTrue(!string.IsNullOrEmpty(item.ModelNumber), "Incorrect model number");
                Assert.IsTrue(!string.IsNullOrEmpty(item.ProductUrl), "Incorrect product url");
                Assert.IsTrue(!string.IsNullOrEmpty(item.CategoryNode), "Incorrect category node");
                Assert.IsTrue(!string.IsNullOrEmpty(item.AddToCartUrl), "Incorrect add to cart url");
                Assert.IsTrue(!string.IsNullOrEmpty(item.AffiliateAddToCartUrl), "Incorrect affiliated add to cart url");
                // Assert.IsTrue(!string.IsNullOrEmpty(item.OfferType), "Incorrect offer type");

                // Image entities can be null in the model
                if (item.ImageEntities != null)
                {
                    int images = 0;  // At least one image expected
                    foreach (var image in item.ImageEntities)
                    {
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect thumbnail image");
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect medium image");
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect large image");
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect entity type");
                        images++;
                    }
                    Assert.IsTrue(images > 0, $"No any image found for the product");
                }

                itemsFound++;
            }

            // Extra validation, item count must match items found in the list
            Assert.IsTrue(itemsFound == itemCount, $"Incorrect list count, found {itemsFound} expected {itemCount   }");
        }

        [TestMethod]
        public void SearchResultSerializationXml_ValidResponse_AgnosticModelFilled()
        {
            var converter = ConverterFactory.GetConverter(WalmartResponseFormat.Xml);
            var responseModel = converter.Convert<WalmartXmlSearchResponse>(_searchResponseSampleXml) as IWalmartSearchResponse;

            // Several asserts to evaluate response correctness
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Query), "query cannot be null");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.ResponseGroup), "response group cannot be null");
            Assert.IsTrue(responseModel.NumItems > 0, "Items must be greater than zero");
            Assert.IsTrue(responseModel.TotalResults > 0, "Total results must be greater than zero");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Sort), "sort cannot be null");

            var itemCount = responseModel.Items.Count();
            Assert.IsTrue(itemCount > 0, "No items found");

            // Assert on individual items
            var itemsFound = 0;
            foreach (var item in responseModel.Items)
            {
                Assert.IsTrue(item.Id > 0, "Incorrect item id");
                Assert.IsTrue(item.Id > 0, "Incorrect parent id");
                Assert.IsTrue(!string.IsNullOrEmpty(item.Name), "Incorrect name");
                Assert.IsTrue(item.SalePrice > 0, "Incorrect sales price");
                Assert.IsTrue(!string.IsNullOrEmpty(item.Upc), "Incorrect UPC");
                Assert.IsTrue(!string.IsNullOrEmpty(item.CategoryPath), "Incorrect category path");
                Assert.IsTrue(!string.IsNullOrEmpty(item.LongDescription), "Incorrect long description");
                Assert.IsTrue(!string.IsNullOrEmpty(item.ThumbnailImage), "Incorrect thumbnail image");
                Assert.IsTrue(!string.IsNullOrEmpty(item.MediumImage), "Incorrect medium image");
                Assert.IsTrue(!string.IsNullOrEmpty(item.LargeImage), "Incorrect large image");
                Assert.IsTrue(!string.IsNullOrEmpty(item.ModelNumber), "Incorrect model number");
                Assert.IsTrue(!string.IsNullOrEmpty(item.ProductUrl), "Incorrect product url");
                Assert.IsTrue(!string.IsNullOrEmpty(item.CategoryNode), "Incorrect category node");
                Assert.IsTrue(!string.IsNullOrEmpty(item.AddToCartUrl), "Incorrect add to cart url");
                Assert.IsTrue(!string.IsNullOrEmpty(item.AffiliateAddToCartUrl), "Incorrect affiliated add to cart url");
                // Assert.IsTrue(!string.IsNullOrEmpty(item.OfferType), "Incorrect offer type");

                // Image entities can be null in the model
                if (item.ImageEntities != null)
                {
                    // Subitems
                    int images = 0;  // At least one image expected
                    foreach (var image in item.ImageEntities)
                    {
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect thumbnail image");
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect medium image");
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect large image");
                        Assert.IsTrue(!string.IsNullOrEmpty(image.ThumbnailImage), "Incorrect entity type");
                        images++;
                    }
                    Assert.IsTrue(images > 0, $"No any image found for the product");
                }

                itemsFound++;
            }

            // Extra validation, item count must match items found in the list
            Assert.IsTrue(itemsFound == itemCount, $"Incorrect list count, found {itemsFound} expected {itemCount   }");
        }
    }
}
