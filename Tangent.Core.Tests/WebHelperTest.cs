using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tangent.Tests;

namespace Tangent.Core.Tests
{
    public class WebHelperTest
    {
        private IWebHelper _webHelper;

        [SetUp]
        public void SetUp()
        {
            _webHelper = new WebHelper();

        }

        [Test]
        public void Can_Modify_Url()
        {
            string apiUri = "/api/employee/";
            _webHelper.ModifyUrl(apiUri, "gender=C").AssertSameStringAs("/api/employee/?gender=C");
        }
    }
}
