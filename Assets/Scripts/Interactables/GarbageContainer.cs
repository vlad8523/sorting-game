using UnityEngine;

namespace Interactables
{
    public class GarbageContainer : MonoBehaviour
    {
        public InteractableType type;

        public void Interact(InteractiveScript interactive)
        {
            Debug.Log(type == interactive.type);
        }
    }
}