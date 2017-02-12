using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffButtonScript : MonoBehaviour {

    public string staffName;

    public void AddStaffToVan()
    {
        GameMaster.Instance.AddStaff(staffName);
    }
}
