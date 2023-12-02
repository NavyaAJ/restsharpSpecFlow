using RestSharp;
using System.Collections.Generic;

namespace restsharpSpecFlow;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestGetRequest()
    {
    var restClient = new RestClient("http://localhost:3000/");
    var request = new RestRequest("posts/{postid}",Method.GET);
    request.AddUrlSegment("postid",1);
    var response = restClient.Execute(request);
    var deserialize = new   RestSharp.Serialization.Json.JsonDeserializer();
    var outputData = deserialize.Deserialize<Dictionary<string,   string>>(response);
    var result = outputData["author"];
    Assert.That(result, Is.EqualTo("type-code"), "Author is not   correct");
    }
}