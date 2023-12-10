using System;
using Interactables;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreContainer : MonoBehaviour
    {
        private static int _score;

        private void OnDisable()
        {
            GarbageContainer.OnUpdateScore -= GarbageContainer_onUpdateScore;
        }
        
        private void OnEnable()
        {
            GarbageContainer.OnUpdateScore += GarbageContainer_onUpdateScore;
        }

        private void GarbageContainer_onUpdateScore(int value)
        {
            _score += value;
            Debug.Log($"current score: {_score}");
        }
    }
}