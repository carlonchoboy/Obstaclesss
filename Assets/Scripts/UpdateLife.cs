using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLife : MonoBehaviour
{
    public Text lifeScore;

    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        lifeScore.text = "Lifes: " + player.life.ToString();
    }
}
