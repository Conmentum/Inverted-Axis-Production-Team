using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

    void OnMouseUp()
    {
        Debug.Log("TowerSpot clicked.");

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

            // FIXME: Right now we assume that we're an object nested in a parent.
            Instantiate(tp.selectedTurret, transform.parent.position, transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

}