using System;
using System.Net;

public interface ApiInterface
{
    string ApiKey { get; set; }

    /// <summary>
    /// Code of language.
    /// Example : ua, uk.
    /// </summary>
    string From { get; set; }

    /// <summary>
    /// Code of language.
    /// Example : ua, uk.
    /// </summary>
    string To { get; set; }

    string Result { get; set; }
    string Sourse { get; set; }

    void GetResult(); 
}