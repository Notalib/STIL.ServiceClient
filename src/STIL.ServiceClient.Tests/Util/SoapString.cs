using System.Globalization;
using STIL.ServiceClient.Util.SoapHelper;

namespace STIL.ServiceClient.Tests.Util;

public class SoapString
{
    private CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
    private CultureInfo DanishCulture = new("da-DK");
    private CultureInfo EnglishUSCulture = new("en-US");
    
    private DateTime dateTime1 = new DateTime(2025,1,1, 0, 0, 0, DateTimeKind.Utc);
    private string expectedOutput = "2025-01-01T00:00:00.000Z";
    
    private DateTime dateTime2 = new DateTime(2025, 1,2,3,4,5,6, DateTimeKind.Utc);
    private string expectedOutput2 = "2025-01-02T03:04:05.006Z";

    [Fact]
    public void TestInvariantCulture()
    {
        Thread.CurrentThread.CurrentCulture = InvariantCulture;
        
        DateTime dateTime2Local = dateTime2.ToLocalTime();
        
        Assert.Equal(expectedOutput, dateTime1.ToSoapString());
        Assert.Equal(expectedOutput2, dateTime2Local.ToSoapString());
    }
    
    [Fact]
    public void TestDanishCulture()
    {
        Thread.CurrentThread.CurrentCulture = DanishCulture;
        
        DateTime dateTime2Local = dateTime2.ToLocalTime();
        string formatedOutput = dateTime2Local.ToUniversalTime().ToString(@"yyyy-MM-ddTHH:mm:ss.fffZ");
        
        Assert.Equal(expectedOutput, dateTime1.ToSoapString());
        Assert.Equal(expectedOutput2, dateTime2Local.ToSoapString());
        Assert.NotEqual(formatedOutput, dateTime2Local.ToSoapString());
    }
    
    [Fact]
    public void TestEnglishUSCulture()
    {
        Thread.CurrentThread.CurrentCulture = EnglishUSCulture;
        
        DateTime dateTime2Local = dateTime2.ToLocalTime();
        
        Assert.Equal(expectedOutput, dateTime1.ToSoapString());
        Assert.Equal(expectedOutput2, dateTime2Local.ToSoapString());
    }    
}
