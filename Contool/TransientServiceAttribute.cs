using System;

namespace Contool
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TransientServiceAttribute : ServiceBaseAttribute
    {
    }
}
