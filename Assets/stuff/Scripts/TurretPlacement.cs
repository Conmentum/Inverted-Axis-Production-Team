using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour {

    public GameObject selectedTurret;
    public void Update()
    {

    }

    public void SelectedTurretType(GameObject turret)
    {
        selectedTurret = turret;
        turret.name = turret.GetComponent<TurretBehaviour>().turretName;
    }
}
