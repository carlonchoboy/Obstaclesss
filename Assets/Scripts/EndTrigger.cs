using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public Gamemanager gameM;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            gameM.completelevel();
        }
    }
}
