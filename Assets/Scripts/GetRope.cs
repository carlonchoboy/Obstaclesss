using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRope : MonoBehaviour
{

    private Rigidbody rigidbody;

    private GameObject attached;

    private bool haveAttached = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (haveAttached)
        {
            attached.transform.position = transform.position;
            if (Input.GetKeyDown(KeyCode.X))
            {
                haveAttached = false;
                attached.GetComponent<Rigidbody>().AddForce(attached.transform.position, ForceMode.Acceleration);
                attached = null;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rigidbody.AddForce(transform.position, ForceMode.Impulse);
            attached = other.gameObject;
            haveAttached = true;
        }
    }
}
