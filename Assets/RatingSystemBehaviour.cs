using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingSystemBehaviour : MonoBehaviour {

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public float finHp;
    public float threshHold1 = 30f;
    public float threshHold2 = 15f;
    public float threshHold3 = 0f;

	// Use this for initialization
	void Start () {
        star1.SetActive(true);
        star2.SetActive(true);
        star3.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        finHp = FindObjectOfType<InventoryController>().lives;
        if (finHp < threshHold1)
        {
            star3.SetActive(false);
            if (finHp < threshHold2)
            {
                star2.SetActive(false);
                if (finHp <= threshHold3)
                {
                    star3.SetActive(false);
                }
            }
        }
	}
}
