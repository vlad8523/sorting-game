using System;
using UnityEngine;

namespace Interactables
{
    public class GarbageContainer : MonoBehaviour
    {
        public GameObject scoreGameObject;
        
        public InteractableType type;

        public static event Action<int> OnUpdateScore;

        private int _score = 100;

        public void Interact(GameObject trashObject)
        {
            var interactive = trashObject.GetComponent<InteractiveScript>();

            if (interactive)
            {
                if (type == interactive.type)
                {
                    OnUpdateScore?.Invoke(_score);
                }
                else
                {
                    OnUpdateScore?.Invoke(-_score);
                }
            }
            
            Destroy(trashObject);
        }
    }
}