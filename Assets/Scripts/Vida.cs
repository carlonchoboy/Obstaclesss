using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Text lifeScore;
    public PlayerCollition player;

    // Update is called once per frame
    void Update()
    {
        lifeScore.text = "Vida:" + player.vida.ToString();
    }
}
