using System;
using System.Collections.Generic;
using Dynamitey.DynamicObjects;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RSDemo1.Model;
using Utf8Json;

namespace RSDemo1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);
            
            //1. use jsonDeserializer 
            var des = new JsonDeserializer();
            var output = des.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];
            Assert.That(result, Is.EqualTo("Karthik KK"), "Author is not correct");


            //2. use JOBJECT
            var obs = JObject.Parse(response.Content);

            Assert.That(obs["author"].ToString(), Is.EqualTo("Karthik KK"), "Author is not correct");

        }



        [Test]
        public void PostWithAnonymousBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = "Raj" });
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            //1. use jsonDeserializer 
            var des = new JsonDeserializer();
            var output = des.Deserialize<Dictionary<string, string>>(response);
            var result = output["name"];
            Assert.That(result, Is.EqualTo("Raj"), "Author is correct");



        }

        [Test]
        public void PostWithBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Post(){Author = "Kenny", Id = 19, Title = "hello world" });

            //1. use jsonDeserializer 
            var response = client.Execute(request);
            var des = new JsonDeserializer();
            var output = des.Deserialize<Dictionary<string, string>>(response);
            var result = output["Author"];
            Assert.That(result, Is.EqualTo("Kenny"), "Author is correct");

            //2.  use strongType Execute.
            var res = client.Execute<Post>(request);
            Assert.That(res.Data.Author, Is.EqualTo("Kenny"), "Author is correct");
        }


        [Test]
        public void PostWithAsync()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Post() { Author = "Kenny", Id = 19, Title = "hello world" });

            var res = client.Execute<Post>(request);
            Assert.That(res.Data.Author, Is.EqualTo("Kenny"), "Author is correct");
        }


    }
}
