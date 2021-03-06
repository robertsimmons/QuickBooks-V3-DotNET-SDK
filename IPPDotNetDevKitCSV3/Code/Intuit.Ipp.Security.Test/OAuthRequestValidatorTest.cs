﻿////*********************************************************
// <copyright file="OAuthRequestValidatorTest.cs" company="Intuit">
//     Copyright (c) Intuit. All rights reserved.
// </copyright>
// <summary>This file contains test cases for OAuthRequestValidatorTest .</summary>
////*********************************************************
using System.Reflection;
namespace Intuit.Ipp.Security.Test
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using Intuit.Ipp.Core;
    using Intuit.Ipp.Exception;
    using Intuit.Ipp.Security;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// This is a test class for OAuthRequestValidatorTest and is intended to contain all OAuthRequestValidatorTest Unit Tests
    /// </summary>
    [TestClass()]
    public class OAuthRequestValidatorTest
    {
        /// <summary>
        /// The test Context Instance.
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor AccessToken Empty
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestAccessTokenEmpty()
        {
            string accessToken = string.Empty;
            string accessTokenSecret = string.Empty;
            string consumerKey = string.Empty;
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor Access Token Secret Empty
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestAccessTokenSecretEmpty()
        {
            string accessToken = "accessToken";
            string accessTokenSecret = string.Empty;
            string consumerKey = string.Empty;
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor Consumer Key Empty
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestConsumerKeyEmpty()
        {
            string accessToken = "accessToken";
            string accessTokenSecret = "accessTokenSecret";
            string consumerKey = string.Empty;
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor Consumer Secret Empty
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestConsumerSecretEmpty()
        {
            string accessToken = "accessToken";
            string accessTokenSecret = "accessTokenSecret";
            string consumerKey = "consumerKey";
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor AccessToken Null
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestAccessTokenNull()
        {
            string accessTokenSecret = string.Empty;
            string consumerKey = string.Empty;
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(null, accessTokenSecret, consumerKey, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor Access Token Secret null
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestAccessTokenSecretNull()
        {
            string accessToken = "accessToken";
            string consumerKey = string.Empty;
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, null, consumerKey, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor Consumer Key null
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestConsumerKeyNull()
        {
            string accessToken = "accessToken";
            string accessTokenSecret = "accessTokenSecret";
            string consumerSecret = string.Empty;
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, null, consumerSecret);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor Consumer Secret Empty
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestConsumerSecretNull()
        {
            string accessToken = "accessToken";
            string accessTokenSecret = "accessTokenSecret";
            string consumerKey = "consumerKey";
            try
            {
                OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, null);
                Assert.Fail();
            }
            catch (InvalidTokenException)
            {
            }
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor 
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTest()
        {
            string accessToken = ConfigurationManager.AppSettings["AccessTokenQBO"];
            string accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecretQBO"];
            string consumerKey = ConfigurationManager.AppSettings["ConsumerKeyQBO"];
            string consumerKeySecret = ConfigurationManager.AppSettings["ConsumerSecretQBO"];
            OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerKeySecret);
            Assert.AreEqual(target.AccessToken, accessToken);
            Assert.AreEqual(target.AccessTokenSecret, accessTokenSecret);
            Assert.AreEqual(target.ConsumerKey, consumerKey);
            Assert.AreEqual(target.ConsumerSecret, consumerKeySecret);
        }

        /// <summary>
        /// A test for OAuthRequestValidator Constructor with App token
        /// </summary>
        [TestMethod()]
        public void OAuthRequestValidatorConstructorTestWithApplicationToken()
        {
            string applicationToken = ConfigurationManager.AppSettings["ApplicationToken"];

            OAuthRequestValidator target = new OAuthRequestValidator(applicationToken);
            Assert.AreEqual(target.AccessToken, null);
            Assert.AreEqual(target.AccessTokenSecret, null);
            Assert.AreEqual(target.ConsumerKey, applicationToken);
            Assert.AreEqual(target.ConsumerSecret, null);
        }

        /// <summary>
        /// A test for Authorize method 
        /// </summary>
        [TestMethod()]
        public void AuthorizeTest()
        {
            string accessToken = ConfigurationManager.AppSettings["AccessTokenQBO"];
            string accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecretQBO"];
            string consumerKey = ConfigurationManager.AppSettings["ConsumerKeyQBO"];
            string consumerKeySecret = ConfigurationManager.AppSettings["ConsumerSecretQBO"];
            string requestUri = "https://appcenter.intuit.com/Developer/Create";
            WebRequest webRequest = WebRequest.Create(requestUri);
            OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerKeySecret);
            target.Authorize(webRequest, string.Empty);
            Assert.IsTrue(webRequest.Headers.Count > 0);
        }

        /// <summary>
        /// A test for Authorize method 
        /// </summary>
        [TestMethod()]
        public void AuthorizeWithHeadersTest()
        {
            string accessToken = ConfigurationManager.AppSettings["AccessTokenQBO"];
            string accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecretQBO"];
            string consumerKey = ConfigurationManager.AppSettings["ConsumerKeyQBO"];
            string consumerKeySecret = ConfigurationManager.AppSettings["ConsumerSecretQBO"];
            string requestUri = "https://appcenter.intuit.com/Developer/Create";
            WebRequest webRequest = WebRequest.Create(requestUri);
            webRequest.Headers.Add("ContentType", "text/xml");
            OAuthRequestValidator target = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerKeySecret);
            target.Authorize(webRequest, string.Empty);
            Assert.IsTrue(webRequest.Headers.Count > 0);
        }

        ///// <summary>
        ///// A test for Authorize method With ApplicationToken
        ///// </summary>
        //[DeploymentItem("Certificates\\idp.pfx","Certificates")]
        //[TestMethod] [Ignore]
        //public void AuthorizeTestWithApplicationToken()
        //{
        //    string applicationToken = ConfigurationManager.AppSettings["ApplicationToken"];
        //    string certificateKeyPassword = ConfigurationManager.AppSettings["CertificateKeyPassword"];
        //    //string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        //    string certificatePath = ConfigurationManager.AppSettings["CertificatePath"];
        //    certificatePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", certificatePath);
        //    Console.WriteLine(certificatePath);
        //    X509Certificate2 certificate = new X509Certificate2(certificatePath, certificateKeyPassword);
        //    string requestUri = "https://appcenter.intuit.com/Developer/Create";
        //    WebRequest webRequest = WebRequest.Create(requestUri);
        //    OAuthRequestValidator target = new OAuthRequestValidator(applicationToken);
        //    target.Key = certificate.PrivateKey;
        //    target.Authorize(webRequest, string.Empty);
        //    Assert.IsTrue(webRequest.Headers.Count > 0);
        //}

        ///// <summary>
        ///// A test for Authorize method With ApplicationToken Without Certificate
        ///// </summary>
        //[TestMethod()]
        //public void AuthorizeTestWithApplicationTokenWithoutCertificate()
        //{
        //    string applicationToken = ConfigurationManager.AppSettings["ApplicationToken"];
        //    string requestUri = "https://appcenter.intuit.com/Developer/Create";
        //    WebRequest webRequest = WebRequest.Create(requestUri);
        //    OAuthRequestValidator target = new OAuthRequestValidator(applicationToken);
        //    try
        //    {
        //        target.Authorize(webRequest, string.Empty);
        //        Assert.Fail();
        //    }
        //    catch
        //    {
        //    }
        //}

        ///// <summary>
        ///// A test for Authorize method With AdditionalParameters
        ///// </summary>
        //[DeploymentItem("Certificates\\idp.pfx", "Certificates")]
        //[TestMethod] [Ignore]
        //public void AuthorizeTestWithAdditionalParameters()
        //{
        //    string applicationToken = ConfigurationManager.AppSettings["ApplicationToken"];
        //    string certificateKeyPassword = ConfigurationManager.AppSettings["CertificateKeyPassword"];
        //    //string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        //    string certificatePath = ConfigurationManager.AppSettings["CertificatePath"];
        //    certificatePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", certificatePath);
        //    X509Certificate2 certificate = new X509Certificate2(certificatePath, certificateKeyPassword);
        //    string requestUri = "https://appcenter.intuit.com/Developer/Create";
        //    WebRequest webRequest = WebRequest.Create(requestUri);
        //    NameValueCollection additionalParams = new NameValueCollection();
        //    additionalParams.Add(CoreConstants.XOAUTHAUTHIDPSEUDONYM, "userName");
        //    additionalParams.Add(CoreConstants.XOAUTHREALMIDPSEUDONYM, "realmId");
        //    additionalParams.Add(CoreConstants.XOAUTHSERVICEPROVIDERID, "serviceProviderId");
        //    OAuthRequestValidator target = new OAuthRequestValidator(applicationToken);
        //    target.AdditionalParameters = additionalParams;
        //    target.Key = certificate.PrivateKey;
        //    target.Authorize(webRequest, string.Empty);
        //    Assert.IsTrue(webRequest.Headers.Count > 0);
        //    Assert.IsTrue(webRequest.Headers["Authorization"].ToString().Contains(CoreConstants.XOAUTHAUTHIDPSEUDONYM));
        //    Assert.IsTrue(webRequest.Headers["Authorization"].ToString().Contains(CoreConstants.XOAUTHREALMIDPSEUDONYM));
        //    Assert.IsTrue(webRequest.Headers["Authorization"].ToString().Contains(CoreConstants.XOAUTHSERVICEPROVIDERID));
        //    Assert.IsTrue(webRequest.Headers["Authorization"].ToString().Contains("userName"));
        //    Assert.IsTrue(webRequest.Headers["Authorization"].ToString().Contains("realmId"));
        //    Assert.IsTrue(webRequest.Headers["Authorization"].ToString().Contains("serviceProviderId"));
        //}
    }
}
