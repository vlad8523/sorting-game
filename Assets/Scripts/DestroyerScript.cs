using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    public GameObject scoreGameObject;

    public static event Action<int> OnUpdateScore;
    
    public int score = -80;

    public void DeleteObject(GameObject trashObject)
    {
        Destroy(trashObject);
        
        OnUpdateScore?.Invoke(score);
    }
}
