using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    public Transform groupTransform;
    public GameObject[] objToSpawn;
    private float _time = 1; 

    public static event Action OnUpdateCountSpawn;

    public float rangeSpawn = 0.5f;
    
    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            if (ManagerContainer.CanSpawn())
            {
                SpawnRandomly();
                _time = 1;
                OnUpdateCountSpawn?.Invoke();
            }
        }
    }

    private void SpawnRandomly()
    {
        int ind = Random.Range(0, objToSpawn.Length);
        Spawn(objToSpawn[ind]);
    }

    private void Spawn(GameObject obj)
    {
        // Debug.Log($"spawning");
        Vector3 spawnPos = transform.position + RandomVector3();
        Instantiate(obj, spawnPos, Quaternion.identity, groupTransform);
    }

    private Vector3 RandomVector3()
    {
        return new Vector3(Random.Range(-rangeSpawn, rangeSpawn), 0, 0);
    }
}
