using System;
using System.Globalization;

namespace STIL.ServiceClient.Util.SoapHelper;

/// <summary>
/// Extension method to format DateTimes so that STIL's IPL Soap server will accept them.
/// </summary>
public static class SoapDateTimeFormatter
{
    private const string _formatString = @"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

    /// <summary>
    /// Formats DateTime as a ISO-8601 UTC string.
    /// </summary>
    /// <param name="dateTime">DateTime.</param>
    /// <returns>Soap friendly formatted DateTime string.</returns>
    public static string ToSoapString(this DateTime dateTime)
    {
        return dateTime.ToUniversalTime().ToString(_formatString, CultureInfo.InvariantCulture);
    }
}
