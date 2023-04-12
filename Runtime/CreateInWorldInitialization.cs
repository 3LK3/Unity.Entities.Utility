using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using Elke.Entities.Utility.Attributes;
using Elke.Entities.Utility.Extensions;
using Unity.Entities;

namespace Elke.Entities.Utility
{
    /// <summary>
    /// Provides a custom Entities world initialization process to be able to create systems in specific worlds.
    /// You can use the <see cref="CreateInWorldAttribute"/> on a system to specify all worlds in wich the system should be created in.
    /// Be aware to also use the <see cref="DisableAutoCreationAttribute"/>. Otherwise your system will always be created.
    /// </summary>
    public static class CreateInWorldInitialization
    {
        /// <summary>
        /// Initializes a new world with systems that a marked to be created in it.
        /// You can use the <see cref="CreateInWorldAttribute"/> on a system to specify all worlds in wich the system should be created in.
        /// Be aware to also use the <see cref="DisableAutoCreationAttribute"/>. Otherwise your system will always be created.
        /// </summary>
        /// <param name="defaultWorldName">Name of the world.</param>
        public static void Initialize(string defaultWorldName)
        {
            // get all world-specific systems by search for all systems with the CreateInWorldAttribute
            var worldSpecificSystems = GetWorldSpecificSystems(defaultWorldName);

            Debug.Log($"Creating world [{defaultWorldName}] with {worldSpecificSystems.Length} specific systems");
            WorldUtility.CreateWorld(defaultWorldName, worldSpecificSystems);
        }

        private static Type[] GetWorldSpecificSystems(string worldName)
        {
            var worldSpecificSystems = new List<Type>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var createInWorlds = type.GetCustomAttribute<CreateInWorldAttribute>();
                    if (createInWorlds != null && createInWorlds.WorldNames.Contains(worldName))
                    {
                        // TODO: Check if the type implements ISystem or SystemBase?
                        worldSpecificSystems.Add(type);
                    }
                }
            }

            return worldSpecificSystems.ToArray();
        }
    }
}
