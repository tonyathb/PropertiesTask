﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTask
{
    class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception e): base(message, e) { }
    }
}
