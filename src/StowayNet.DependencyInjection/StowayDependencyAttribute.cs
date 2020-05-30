using System;
using System.Collections.Generic;
using System.Text;

namespace StowayNet
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class StowayDependencyAttribute : Attribute
    {
        public StowayDependencyType Type { get; set; }

        public StowayDependencyAttribute(StowayDependencyType type)
        {
            Type = type;
        }
    }
}
