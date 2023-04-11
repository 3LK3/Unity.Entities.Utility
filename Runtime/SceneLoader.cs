using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Elke.Entities.Utility
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                Debug.Log("Load scene progress: " + operation.progress);
                if (operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
