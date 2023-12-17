using System;
using Interactables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Utils
{
    public class ManagerContainer : MonoBehaviour
    {
        public static int Score;
        public int countSpawn = 5;
        
        private static int _countSpawn;
        private static int _countNonDestroyedObject;

        
        
        [SerializeField] private UnityEvent<int> scoreChanged;
        [SerializeField] private UnityEvent<int> countSpawnChanged;
        
        private void OnDisable()
        {
            GarbageContainer.OnUpdateScore -= _onUpdateScore;
            DestroyerScript.OnUpdateScore -= _onUpdateScore;
            SpawnerScript.OnUpdateCountSpawn -= _onUpdateCountSpawn;
            
            GarbageContainer.OnDeleteTrash -= _onDestroyedObject;
            DestroyerScript.OnDeleteTrash -= _onDestroyedObject;
        }
        
        
        private void OnEnable()
        {
            GarbageContainer.OnUpdateScore += _onUpdateScore;
            DestroyerScript.OnUpdateScore += _onUpdateScore;
            SpawnerScript.OnUpdateCountSpawn += _onUpdateCountSpawn;

            GarbageContainer.OnDeleteTrash += _onDestroyedObject;
            DestroyerScript.OnDeleteTrash += _onDestroyedObject;
        }

        
        private void _onUpdateScore(int value)
        {
            Score += value;
            Debug.Log($"current score: {Score}");
            scoreChanged.Invoke(Score);
        }

        
        private void _onUpdateCountSpawn()
        {
            _countSpawn -= 1;
            countSpawnChanged.Invoke(_countSpawn);
        }

        
        private void _onDestroyedObject()
        {
            _countNonDestroyedObject -= 1;
            
            Debug.Log($"_countNonDestroyedObject: {_countNonDestroyedObject}");

            if (_countNonDestroyedObject == 0)
            {
                Debug.Log("Gameend");
                SceneManager.LoadScene("Scenes/ScoreMenu");
            }
        }

        
        public static bool CanSpawn()
        {
            return _countSpawn > 0;
        }
        
        
        private void Start()
        {
            _countNonDestroyedObject = countSpawn;
            _countSpawn = countSpawn;
            Score = 0;
            
            scoreChanged.Invoke(Score);
            countSpawnChanged.Invoke(_countSpawn);
        }
    }
}