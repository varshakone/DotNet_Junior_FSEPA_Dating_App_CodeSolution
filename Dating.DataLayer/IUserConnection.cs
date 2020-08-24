using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.DataLayer
{
    public interface IUserConnection
    {
        UserContext GetUserContext { get; }
    }
}
