using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;

namespace martinhromek.bitcoin
{
  public class comm
  {
    [DataContract]
    public class Response
    {
      [DataMember(Name = "code")]
      public string Code { get; set; }
      [DataMember(Name = "rate")]
      public string Rate { get; set; }
      [DataMember(Name = "statusCode")]
      public int StatusCode { get; set; }
      [DataMember(Name = "statusDescription")]
      public string StatusDescription { get; set; }
      [DataMember(Name = "authenticationResultCode")]
      public string AuthenticationResultCode { get; set; }
      [DataMember(Name = "errorDetails")]
      public string[] errorDetails { get; set; }
      [DataMember(Name = "traceId")]
      public string TraceId { get; set; }
      //[DataMember(Name = "resourceSets")]
      //public ResourceSet[] ResourceSets { get; set; }
    }

    public static Response MakeRequest(string requestUrl)
    {
      try
      {
        HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
          if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception(String.Format(
            "Server error (HTTP {0}: {1}).",
            response.StatusCode,
            response.StatusDescription));
          DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
          object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
          Response jsonResponse
          = objResponse as Response;
          return jsonResponse;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return null;
      }
    }

    public static string GET(string url)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      try
      {
        WebResponse response = request.GetResponse();
        using (Stream responseStream = response.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
          return reader.ReadToEnd();
        }
      }
      catch (WebException ex)
      {
        WebResponse errorResponse = ex.Response;
        using (Stream responseStream = errorResponse.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
          String errorText = reader.ReadToEnd();
          // log errorText
        }
        throw;
      }
    }
  }
}