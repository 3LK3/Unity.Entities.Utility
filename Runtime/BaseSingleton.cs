using UnityEngine;

namespace Spindler.Utilities
{
    /// <summary>
    /// Base class for singleton MonoBehaviour.
    /// </summary>
    /// <typeparam name="T">Your singleton type</typeparam>
    public abstract class BaseSingleton<T> : MonoBehaviour where T : BaseSingleton<T>
    {
        public static T Instance;

        protected void AwakeInstance(T instance)
        {
            if (Instance != null)
            {
                // There can only be one instance. Just throw an exception atm. Better alternative?
                // Basically happens during development, so the dev needs to know what's wrong.
                // Destroying the object that comes second seems random.
                // Destroy(instance);
                throw new System.Exception($"There can only be one instance of {typeof(T)}.");
            }
            else
            {
                Instance = instance;
            }
        }
    }
}
