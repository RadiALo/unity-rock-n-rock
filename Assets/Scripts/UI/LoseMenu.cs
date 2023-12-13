using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject loseMenu;

    public void ShowLoseWindow()
    {
        loseMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
