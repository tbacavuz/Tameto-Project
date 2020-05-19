using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOPOS.Models.Enums
{
    public enum Status
    {
        Waiting = 1,
        InQueue = 2,
        Preparing =3,
        OnTheWay = 4,
        End = 5
    }
}