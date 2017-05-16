using DenDream.Marketplace.Walmart.SDK;
using DenDream.Marketplace.Walmart.SDK.Converters;
using DenDream.Marketplace.Walmart.SDK.Model;
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
        public void SearchResultSerializationXml_ValidResponse_ModelPropertiesFilled()
        {
            var converter = ConverterFactory.GetConverter(WalmartResponseFormat.Xml);
            var responseModel = converter.Convert<WalmartXmlSearchResponse>(_searchResponseSampleXml);
            
            // Several asserts to evaluate response correctness
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Query), "query cannot be null");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.ResponseGroup), "response group cannot be null");
            Assert.IsTrue(responseModel.NumItems > 0, "Items must be greater than zero");
            Assert.IsTrue(responseModel.TotalResults > 0, "Total results must be greater than zero");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Sort), "sort cannot be null");

            var itemCount = responseModel.Result.Items.Count;
            Assert.IsTrue(itemCount > 0, "No items found");

            // Assert on individual items
            var itemsFound = 0;
            foreach (var item in responseModel.Result.Items)
            {
                Assert.IsTrue(item.Id > 0, "Inccorect item id");
                itemsFound++;
            }

            // Extra validation, item count must match items found in the list
            Assert.IsTrue(itemsFound == itemCount, $"Incorrect list count, found {itemsFound} expected {itemCount   }");
        }

        [TestMethod]
        public void SearchResultSerializationJson_ValidResponse_ModelPropertiesFilled()
        {
            var converter = ConverterFactory.GetConverter(WalmartResponseFormat.Json);
            var responseModel = converter.Convert<WalmartJsonSearchResponse>(_searchResponseSampleJson);

            // Several asserts to evaluate response correctness
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Query), "query cannot be null");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.ResponseGroup), "response group cannot be null");
            Assert.IsTrue(responseModel.NumItems > 0, "Items must be greater than zero");
            Assert.IsTrue(responseModel.TotalResults > 0, "Total results must be greater than zero");
            Assert.IsFalse(string.IsNullOrEmpty(responseModel.Sort), "sort cannot be null");

            var itemCount = responseModel.Items.Count;
            Assert.IsTrue(itemCount > 0, "No items found");

            // Assert on individual items
            var itemsFound = 0;
            foreach (var item in responseModel.Items)
            {
                Assert.IsTrue(item.Id > 0, "Inccorect item id");
                itemsFound++;
            }

            // Extra validation, item count must match items found in the list
            Assert.IsTrue(itemsFound == itemCount, $"Incorrect list count, found {itemsFound} expected {itemCount   }");
        }
    }
}
