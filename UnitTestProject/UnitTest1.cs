using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            RestClient _RClient = new RestClient
            {
                BaseUrl = new Uri("http://localhost:5000/api/")
            };
            _RClient.DefaultParameters.Clear();
            _RClient.AddDefaultHeader("Content-Type", "application/json");
            _RClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var Rrequest = new RestRequest("App/GetLicenceCountForApp/" + 374);
            var varResult = _RClient.GetAsync<int>(Rrequest).Result;
            Assert.IsTrue(varResult > 0);            
        }
    }
}
