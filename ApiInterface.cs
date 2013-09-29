using System;
using System.Net;

public interface ApiInterface
{
    public WebResponse ResponseObj { get; set; }

    public WebRequest RequestObj { get; set; }

    private string _apiKey;
    public string ApiKey
    {
        get { return _apiKey; }
        set { _apiKey = value; }
    }
    /// <summary>
    /// Code of language.
    /// Example : ua, uk.
    /// </summary>
    public string From{get;set;}

    /// <summary>
    /// Code of language.
    /// Example : ua, uk.
    /// </summary>
    public string To{get;set;}

    public string ResponseText { get; set; }

    public void GetResponse(); 
   
}
