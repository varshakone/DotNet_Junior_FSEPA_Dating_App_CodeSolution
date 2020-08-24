using System;

namespace Dating.DataLayer
{
    public class DateConnection : IDateConnection
    {
        private readonly DatingContext _datingContext;
        public DateConnection(DatingContext datingContext)
        {
            _datingContext = datingContext;
        }
        public DatingContext GetDatingContext => _datingContext;
    }
}
