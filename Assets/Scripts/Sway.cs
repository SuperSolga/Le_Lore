using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    #region Variables

    public float intensity;
    public float smooth;

    private Quaternion originRotation;

    #endregion

    #region MonoBehavior Callbacks

    private void Start()
    {
        originRotation = transform.localRotation;
    }

    private void Update()
    {
        UpdateSway();
    }

    #endregion

    #region Private Methods

    private void UpdateSway()
    {
        //controls
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

        //calculate target rotation
        Quaternion Xadjustment = Quaternion.AngleAxis(-intensity * xMouse, Vector3.up);
        Quaternion Yadjustment = Quaternion.AngleAxis(intensity * yMouse, Vector3.right);
        Quaternion targetRotation = originRotation * Xadjustment * Yadjustment;

        //apply rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

    #endregion
}
