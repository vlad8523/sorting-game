using System;
using Interactables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class ScoreContainer : MonoBehaviour
    {
        private static int _score;
        
        [FormerlySerializedAs("ScoreChanged")] [SerializeField] private UnityEvent<int> scoreChanged;
            
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
            scoreChanged.Invoke(_score);
        }

        private void Awake()
        {
            scoreChanged.Invoke(_score);
        }
    }
}