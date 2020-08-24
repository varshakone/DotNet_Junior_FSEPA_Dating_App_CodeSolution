using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.DataLayer
{
   public interface IDateConnection
    {
        DatingContext GetDatingContext { get; }
    }
}
