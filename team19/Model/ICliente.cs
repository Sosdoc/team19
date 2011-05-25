using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public interface ICliente : ISoggetto
    {
        string CodiceFiscale
        {
            get;
        }
    }
}
