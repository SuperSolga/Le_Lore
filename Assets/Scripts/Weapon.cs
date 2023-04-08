using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables
    public Gun[] loadout;
    public Transform weaponParent;

    private GameObject currentObject;
    #endregion

    #region MonoBehavior Callbacks
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
    }
    #endregion

    #region Private Methods
    void Equip(int index) 
    { 
        if(currentObject != null) Destroy(currentObject);

        GameObject newEquipment = Instantiate(loadout[index].prefab, weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        newEquipment.transform.localPosition = Vector3.zero;
        newEquipment.transform.localEulerAngles = Vector3.zero;

        currentObject= newEquipment;
    }
    #endregion
}
