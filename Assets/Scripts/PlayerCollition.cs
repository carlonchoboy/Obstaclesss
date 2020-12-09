using UnityEngine;

public class PlayerCollition : MonoBehaviour
{

    public PlayerController movimiento;
    public int vida;
    public Gamemanager gm;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstaculo")
        {
            vida -= 1;
        }
        if (vida == 0)
        {
            movimiento.enabled = false;
            FindObjectOfType<Gamemanager>().EndGame();
        }
    }
}
