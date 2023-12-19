using TMPro;
using UnityEngine;

namespace UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void ShowScore(int value)
        {
            _text.text = value.ToString();
        }

    }
}
