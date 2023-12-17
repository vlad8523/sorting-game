using System;
using Interactables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class ManagerContainer : MonoBehaviour
    {
        private static int _score;
        private static int _countSpawn = 5;
        
        [SerializeField] private UnityEvent<int> scoreChanged;
        [SerializeField] private UnityEvent<int> countSpawnChanged;
            
        private void OnDisable()
        {
            GarbageContainer.OnUpdateScore -= _onUpdateScore;
            DestroyerScript.OnUpdateScore -= _onUpdateScore;
            SpawnerScript.OnUpdateCountSpawn -= _onUpdateCountSpawn;
        }
        
        private void OnEnable()
        {
            GarbageContainer.OnUpdateScore += _onUpdateScore;
            DestroyerScript.OnUpdateScore += _onUpdateScore;
            SpawnerScript.OnUpdateCountSpawn += _onUpdateCountSpawn;
        }

        private void _onUpdateScore(int value)
        {
            _score += value;
            Debug.Log($"current score: {_score}");
            scoreChanged.Invoke(_score);
        }

        private void _onUpdateCountSpawn()
        {
            _countSpawn -= 1;
            Debug.Log($"obj to spawn: {_countSpawn}");
            countSpawnChanged.Invoke(_countSpawn);
        }

        public static bool CanSpawn()
        {
            return _countSpawn > 0;
        }

        private void Awake()
        {
            scoreChanged.Invoke(_score);
            countSpawnChanged.Invoke(_countSpawn);
        }
    }
}