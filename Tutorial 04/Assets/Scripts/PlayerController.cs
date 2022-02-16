using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float movementX, movementY;
    [SerializeField] private float speed;

    private int count = 0;
    public TextMeshProUGUI countText, winText;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        countText.SetText("Count: " + count);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rigidBody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            count++;
            countText.SetText("Count: " + count);
        }
        if (count == 10)
        {
            winText.GetComponent<TextMeshProUGUI>().enabled = true;
        }
           
    }
}
