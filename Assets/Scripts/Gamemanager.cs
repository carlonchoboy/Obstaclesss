using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;
    public Text life;
    public Text distance;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;

    public void completelevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            life.enabled = false;
            distance.enabled = false;
            gameEnded = true;
            Invoke("Restart",restartDelay);
            gameOverUI.SetActive(true);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("FirstLevel");
    }

}
