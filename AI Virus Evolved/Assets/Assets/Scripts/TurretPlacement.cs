using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour {

    public GameObject selectedTurret;

    public void SelectedTurretType(GameObject turret)
    {
        selectedTurret = turret;
    }
}
