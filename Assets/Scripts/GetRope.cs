using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRope : MonoBehaviour
{

    private Rigidbody rigidbody;

    private GameObject attached;

    private bool haveAttached = false;

    private float lastPosx;

    // Start is called before the first frame update
    void Start()
    {
        lastPosx = transform.position.x;
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
                //if (transform.position.x > lastPosx)
                //{
                //    attached.GetComponent<Rigidbody>().AddForce(attached.transform.position);

                //}
                //else
                //{
                //    attached.GetComponent<Rigidbody>().AddForce(attached.transform.position * -1 * 100);
                //}
                attached.GetComponent<Rigidbody>().AddForce(attached.transform.position);
                attached = null;
            }
        }
        lastPosx = transform.position.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rigidbody.AddForce(transform.position, ForceMode.Impulse);
            attached = other.gameObject;
            haveAttached = true;
        }
    }
}
