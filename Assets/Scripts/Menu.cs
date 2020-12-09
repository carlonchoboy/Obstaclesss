using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GameMenu()
    {
        Debug.Log("Arranca");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
