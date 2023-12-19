using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICountSpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ShowCountSpawn(int value)
    {
        _text.text = value.ToString();
    }
}
