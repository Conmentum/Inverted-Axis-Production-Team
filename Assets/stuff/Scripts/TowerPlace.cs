using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {
    //Rework for android
    void OnMouseUp()
    {
        Debug.Log("TowerPlace clicked.");

        TurretPlacement tp = GameObject.FindObjectOfType<TurretPlacement>();
        if (tp.selectedTurret != null)
        {
             InventoryController ic = GameObject.FindObjectOfType<InventoryController>();
            if (ic.currency < tp.selectedTurret.GetComponent<TurretBehaviour>().cost)
            {
                Debug.Log("Not enough money!");
                return;
            }

            ic.currency -= tp.selectedTurret.GetComponent<TurretBehaviour>().cost;

            // FIXME: Right now we assume that this is an object nested in a parent.
            Instantiate(tp.selectedTurret, transform.parent.position, transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

}