using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public float restartDelay = 1f;

    public Text lifeText;

    public Text timeText;

    public GameObject completeLevelUI;

    public GameObject gameOverUI;

    private GameObject player;

    private bool gameEnded = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CheckDead();
        if (Input.GetKey(KeyCode.R)){
            RestartLevel();
        }
    }

    public void CheckDead()
    {
        if(player.transform.position.y <= -10)
        {
            player.GetComponent<PlayerController>().life--;
            if(player.GetComponent<PlayerController>().life <= 0)
            {
                EndGame();
            }
            else
            {
                Vector3 initialPosition = new Vector3(0, 1, 0);
                player.transform.position = initialPosition;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
    }

    public void completelevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            lifeText.enabled = false;
            timeText.enabled = false;
            gameEnded = true;
            //Invoke("Restart", restartDelay);
            gameOverUI.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }

}
