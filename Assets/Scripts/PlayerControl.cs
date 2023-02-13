using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public float jumpForce;

    public Camera normalCam;
    public Transform groundDetector;
    public LayerMask ground;

    private Rigidbody rig;
    private float baseFOV = 60f;
    private float sprintFOV = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        baseFOV = normalCam.fieldOfView;
        Camera.main.enabled = false;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Input
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        //Controls
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKey(KeyCode.Space);

        //States
        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && vMove > 0 && !isJumping;

        Vector3 move = new Vector3(hMove, 0, vMove);
        move.Normalize();

        //Jump
        if(isJumping)
        {
            rig.AddForce(Vector3.up * jumpForce);
        }

        //Sprint, Walk
        float finalSpeed = speed;
        if (isSprinting)
        {
            finalSpeed *= sprintSpeed;
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOV, Time.deltaTime * 8f);
        }
        else 
        { 
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
        }


        Vector3 targetVelocity = transform.TransformDirection(move) * finalSpeed * Time.deltaTime;
        targetVelocity.y = rig.velocity.y;
        rig.velocity = targetVelocity;
    }
}
