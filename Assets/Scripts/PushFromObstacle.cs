using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushFromObstacle : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.position - player.transform.position;
        direction.y = 0;
        direction.z = 0;
        player.GetComponent<Rigidbody>().AddForce(direction.normalized * 1000, ForceMode.Impulse);
    }
}
