﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsor.Test.cwLog
{
    public interface IWriter
    {
        void WriteLine(string output);
    }
}
