using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.Components.NBPWeb
{
    public interface ICurrencyNbpConnector
    {
        Task<Currency> Fetch(string code);
    
    }
}
