﻿using DI.Services;
using vuln_netframework.Models;
using System.Web.Http;

namespace vuln_netframework.Controllers
{
    [RoutePrefix("api/insecuredeserialization")]
    public class InsecureDeserializationController : ApiController
    {
        private IInsecureDeserializationService _insecureDeserialization;

        public InsecureDeserializationController(IInsecureDeserializationService insecureDeserialization)
        {
            _insecureDeserialization = insecureDeserialization;
        }

        [Route("index")]
        public string GetIndex()
        {
            return "Welcome Insecure Deserialization Page";
        }

        /*
         * Request method can defined via multiple way:
         *  1) Metadata like [HttpPost], etc.
         *  2) Prefix of method name like PostNewtonsoftID
         *  3) in WebApiConfig.cs
         */
        [Route("newtonsoft")]
        public void PostNewtonsoftDeserialization([FromBody] string json)
        {
            _insecureDeserialization.NewtonsoftDeserialization(json);
        }

        [Route("newtonsoft/objectbinding")]
        public string PostObjectBinding([FromBody] NewtonsoftInsecureDeserializationModel model)
        {
            return "Object Binded";
        }

        [Route("binaryformatter")]
        public void PostBinaryDeserialization([FromBody] string json)
        {
            _insecureDeserialization.BinaryFormatterDeserialization(json);
        }

        [Route("datacontractjsondeserialization")]
        public void PostDataContractJsonDeserialization([FromBody] DataContractInsecureDeserializationModel obj)
        {
            _insecureDeserialization.DataContractJsonDeserialization(obj.T, obj.Model);
        }
    }
}