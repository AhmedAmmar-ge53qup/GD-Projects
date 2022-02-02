using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] 
    private GameObject bullet;
    public float power = 1500.0f, moveSpeed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Mouse X") * Time.deltaTime * moveSpeed;
        //float verticalInput = Input.GetAxis("Mouse Y") * Time.deltaTime * moveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(horizontalInput, verticalInput, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject instance = Instantiate(bullet, transform.position, transform.rotation);
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            instance.GetComponent<Rigidbody>().AddForce(fwd * power);
            instance.GetComponent<AudioSource>().Play();
            
        }
    }
}
