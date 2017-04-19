using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTurret : MonoBehaviour {
    //this script is attached to the IMG named LockIMG
    public float currentCurrency;
    public float towerCost;
    //Dragged in via inspector, 
    public GameObject towerSelected;

    void Start()
    {
        
        towerCost = towerSelected.GetComponent<TurretBehaviour>().cost;
    }
    // Update is called once per frame
    void Update () {
		currentCurrency = GameObject.FindObjectOfType<InventoryController>().currency;
        if (towerCost > currentCurrency)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
