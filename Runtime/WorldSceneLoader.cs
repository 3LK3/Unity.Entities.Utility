using System.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Elke.Entities.Utility
{
    /// <summary>
    /// In order to load a scene and create corresponding Entities world you can use the LoadWorldAndScene methods.
    /// This is a MonoBehaviour as well as a BaseSingleton.
    /// The Entites world is created before loading the new scene. The scene will be activated when fully loaded.
    /// </summary>
    public class WorldSceneLoader : BaseSingleton<WorldSceneLoader>
    {
        /// <summary>
        /// Creates a new world by starting the Entities <see cref="DefaultWorldInitialization"/> process and loads the desired scene.
        /// This scene will be activated once fully loaded.
        /// All existing Entity worlds will be disposed before creating the new one.
        /// </summary>
        /// <param name="sceneAndWorldName">Name of scene and world.</param>
        public void LoadWorldAndScene(string sceneAndWorldName)
        {
            LoadWorldAndScene(sceneAndWorldName, true);
        }

        /// <summary>
        /// Creates a new world by starting the Entities <see cref="DefaultWorldInitialization"/> process and loads the desired scene.
        /// This scene will be activated once fully loaded.
        /// </summary>
        /// <param name="sceneAndWorldName">Name of scene and world.</param>
        /// <param name="disposeExistinWorlds">Whether to dispose all existing Entities worlds. <b>Default: true</b></param>
        public void LoadWorldAndScene(string sceneAndWorldName, bool disposeExistinWorlds = true)
        {
            if (disposeExistinWorlds)
            {
                World.DisposeAllWorlds();
            }

            DefaultWorldInitialization.Initialize(sceneAndWorldName);

            StartCoroutine(LoadSceneAsync(sceneAndWorldName));
        }

        private void Awake()
        {
            AwakeInstance(this);
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                // Debug.Log("Load scene progress: " + operation.progress);
                if (operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
