using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class UIScoreMenu : MonoBehaviour
    {
        public TextMeshProUGUI _text;
        void Start()
        {
            Debug.Log(ManagerContainer.Score);
            _text.text = ManagerContainer.Score.ToString();
        }
    
    }
}
