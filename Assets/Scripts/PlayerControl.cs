using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.enabled = false;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hMove, 0, vMove);
        move.Normalize();

        rig.velocity = move * speed * Time.deltaTime;
    }
}
