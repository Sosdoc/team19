﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    interface IRiepilogo
    {
        List<Currency> GetImportiPagati();
        List<Currency> GetImportiDaPagare();
    }
}
