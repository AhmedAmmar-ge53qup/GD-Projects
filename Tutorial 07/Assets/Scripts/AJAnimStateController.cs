using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJAnimStateController : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash, isRunningHash, isJumpingHash;

    [SerializeField]
    private float speed = 5.0f, rotationSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {

        // Movement
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            // Walking
            bool forwardPressed = Input.GetKey(KeyCode.W);
            animator.SetBool(isWalkingHash, forwardPressed);

            // Running
            bool runPressed = Input.GetKey(KeyCode.LeftShift);
            animator.SetBool(isRunningHash, forwardPressed && runPressed);

            // Jumping
            bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
            if (runPressed && jumpPressed)
                animator.SetTrigger(isJumpingHash);
        }
    }
}
