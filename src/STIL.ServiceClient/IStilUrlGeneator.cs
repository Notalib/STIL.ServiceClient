using System;

namespace STIL.ServiceClient
{
    public interface IStilUrlGeneator
    {
        Uri Generate(string methodName);
    }
}
