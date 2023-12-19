using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIMainMenuScript : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Scenes/Game");
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
