using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    public Transform groupTransform;
    public GameObject[] objToSpawn;
    private float _time = 1;

    private void Start()
    {
    }

    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            {
                SpawnRandomly();
                _time = 1;
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
        Debug.Log($"spawning");
        Vector3 spawnPos = transform.position;
        Instantiate(obj, spawnPos, Quaternion.identity, groupTransform);
    }
}
