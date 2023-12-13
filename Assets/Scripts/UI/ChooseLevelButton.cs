using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelButton : MonoBehaviour
{
    [SerializeField]
    private int level;

    public void OpenLevel()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
