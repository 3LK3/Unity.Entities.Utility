using System;

namespace Elke.Entities.Utility.Attributes
{
    /// <summary>
    /// Attribute to specify the entity worlds a system should be created in.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class CreateInWorldAttribute : Attribute
    {
        private readonly string[] m_WorldNames;

        public CreateInWorldAttribute(params string[] worldNames)
        {
            m_WorldNames = worldNames;
        }

        public string[] WorldNames => m_WorldNames;
    }
}
