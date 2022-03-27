using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject onhand;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rb.useGravity)
        {
            rb.transform.position = onhand.transform.position + new Vector3(0, 0, 1);
        }
    }

    private void OnMouseDown()
    {
        rb.useGravity = false;
        rb.transform.position = onhand.transform.position;
        rb.transform.parent = GameObject.Find("Super First Person Controller").transform;
    }

    private void OnMouseUpAsButton()
    {
        rb.transform.parent = null;
        rb.useGravity = true;
    }
}
