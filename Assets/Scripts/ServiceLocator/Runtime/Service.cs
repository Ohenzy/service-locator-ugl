using UnityEngine;
using UnityEngine.SceneManagement;

namespace UGL.ServiceLocator
{
    [DefaultExecutionOrder(int.MinValue)]
    public class Service : MonoBehaviour
    {
        public static T Get<T>() => ServiceLocator.instance.Get<T>();

        private void Awake()
        {
            var builder = new ServiceBuilder();
            var scene = SceneManager.GetActiveScene();

            foreach (var go in scene.GetRootGameObjects())
            {
                foreach (var installer in go.GetComponentsInChildren<MonoInstaller>())
                {
                    installer.Install(builder);
                }
            }
        }

        private void OnDestroy() => ServiceLocator.instance.Clear();
    }
}