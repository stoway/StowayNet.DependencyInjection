using System;
using System.Collections.Generic;
using System.Text;

namespace StowayNet
{
    public enum StowayDependencyType
    {
        None = 0,
        Transient = 1,
        Scoped = 2,
        Singleton = 3,
    }
}
