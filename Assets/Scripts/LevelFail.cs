using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFail : MonoBehaviour
{
    public void resetlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}