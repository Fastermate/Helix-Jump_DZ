using UnityEngine;

namespace Assembly_CSharp
{
    public class Platform : MonoBehaviour
    {
        public Platform platform;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                BoxCollider.Destroy(platform);
            }
        }
    }
}