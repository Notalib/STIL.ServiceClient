using System;

namespace STIL.ServiceClient
{
    public interface IStilUrlGenerator
    {
        Uri Generate(string methodName);
    }
}
