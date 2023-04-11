using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using Elke.Entities.Utility.Attributes;
using Elke.Entities.Utility.Extensions;

namespace Elke.Entities.Utility
{
    public static class CreateInWorldInitialization
    {
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
