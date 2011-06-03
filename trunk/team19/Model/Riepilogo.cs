using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace Team19.Model
{
    public interface IRiepilogo
    {
        Dictionary<int, Currency> GetImportiPagati();
        Dictionary<int, Currency> GetImportiDaPagare();
    }
    

}
