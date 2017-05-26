using DenDream.Marketplace.Walmart.SDK.Exceptions;
using DenDream.Marketplace.Walmart.SDK.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Tests
{
    [TestClass]
    public class DomainFactoriesTesst
    {
        SearchParametersFactory _searchParametersFactory;

        [TestInitialize]
        public void SetUp()
        {
            _searchParametersFactory = new SearchParametersFactory();
        }

        [TestMethod]
        public void CreateSearchParameters_OnlyQuery_ObtainSearchWithQueryAndDefaults() 
        {
            var searchPhrase = "search this phrase";
            var search = _searchParametersFactory.Get(searchPhrase);
            Assert.IsTrue(search.Query == searchPhrase);
            Assert.IsTrue(search.Order == SearchParametersFactory.DefaultSortOrder);
            Assert.IsTrue(search.Sort == SearchParametersFactory.DefaultSortCriteria);
            Assert.IsTrue(search.ResponseGroup == SearchParametersFactory.DefaultResponseGroup);
            Assert.IsTrue(search.Format == SearchParametersFactory.DefaultResponseFormat);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSearchParameterException))]
        public void CreateSearchParameters_InvalidStart_ThrowsException()
        {
            var search = _searchParametersFactory.Get("some search", null, null, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSearchParameterException))]
        public void CreateSearchParameters_InvalidLowNumItems_ThrowsException()
        {
            var search = _searchParametersFactory.Get("some search", null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSearchParameterException))]
        public void CreateSearchParameters_InvalidHighNumItems_ThrowsException()
        {
            var search = _searchParametersFactory.Get("some search", null, 26);
        }
    }
}
