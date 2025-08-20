using UnityEngine;

namespace UGL.ServiceLocator
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void Install(ServiceBuilder builder);
    }
}