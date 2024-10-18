using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIL.ServiceClient
{
    public interface IStilUrlGeneator
    {
        Uri Generate(string methodName);
    }
}
