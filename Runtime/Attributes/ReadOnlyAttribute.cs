using System;
using UnityEngine;

namespace Elke.Entities.Utility.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }
}
