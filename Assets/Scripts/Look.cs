using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{

    public Transform player;
    public Transform cams;

    public float xSensitivity;
    public float ySensitivity;
    public float maxAngle;

    private Quaternion camCenter;

    // Start is called before the first frame update
    void Start()
    {
        camCenter = cams.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
    }

    void SetY ()
    {
        float input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        Quaternion adjust = Quaternion.AngleAxis(input, -Vector3.right);
        Quaternion delta = cams.localRotation * adjust;
        
        if (Quaternion.Angle(camCenter, delta) < maxAngle)
        {
            cams.localRotation = delta;
        }
    }
}
