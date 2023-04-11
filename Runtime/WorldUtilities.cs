using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Elke.Entities.Utility
{
    public class WorldUtility
    {
        public static World CreateWorld(string defaultWorldName, params Type[] customSystems)
        {
            var world = new World(defaultWorldName, WorldFlags.Game);
            World.DefaultGameObjectInjectionWorld ??= world;

            var allSystems = new List<Type>();
            allSystems.AddRange(DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.Default));
            allSystems.AddRange(customSystems);

            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(world, allSystems);

            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(world);

            return world;
        }

        public static void DestroyWorld(WorldFlags flags)
        {
            DestroyWorld(world => world.Flags == flags);
        }

        public static void DestroyWorld(string name)
        {
            DestroyWorld(world => world.Name == name);
        }

        private static void DestroyWorld(Predicate<World> shouldDestroy)
        {
            var hasDestroyed = false;

            foreach (var world in World.All)
            {
                if (shouldDestroy(world))
                {
                    Debug.Log($"Destroying world: {world.Name}");
                    world.Dispose();
                    hasDestroyed = true;
                    break;
                }
            }

            if (!hasDestroyed)
            {
                Debug.LogWarning("No world has been destroyed. Please check your condition.");
            }
        }
    }
}
