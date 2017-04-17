using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject normPathObj;
    GameObject flyingPathObj;
    public GameObject DeathEffect;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    
    public Image Healthbar;

    [SerializeField]
    private float WTFPLS;

    [Header("Stats")]
    public float speed;
    public int damage;
    public float health;
    public float CurrentHealth;
    public int curValue;

    // Use this for initialization
    void Start()
    {
        //Healthbar = GetComponent<Image>();

        CurrentHealth = health;
        Debug.Log("Health set");

        normPathObj = GameObject.Find("Normal Path");
        flyingPathObj = GameObject.Find("Flying Path");
    }

    void GetNextNode()
    {
        if (this.gameObject.name != "Enemy_Aerial(Clone)")
        {
            if (pathNodeIndex < normPathObj.transform.childCount)
            {
                targetPathNode = normPathObj.transform.GetChild(pathNodeIndex);
                pathNodeIndex++;
            }
            else
            {
                targetPathNode = null;
                BaseReached();
            }
        }
        if (this.gameObject.name == "Enemy_Aerial(Clone)")
        {
            if (pathNodeIndex < flyingPathObj.transform.childCount)
            {
                targetPathNode = flyingPathObj.transform.GetChild(pathNodeIndex);
                pathNodeIndex++;
            }
            else
            {
                targetPathNode = null;
                BaseReached();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentHealth <= 0)
        {
            Die();
            Instantiate(DeathEffect, transform.position, transform.rotation);
        }
        if (targetPathNode == null)
        {
            GetNextNode();
            if (targetPathNode == null)
            {
                BaseReached();
                return;
            }
        }

        Vector3 direction = targetPathNode.position - this.transform.localPosition;

        float distanceByFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceByFrame)
        {
            targetPathNode = null;
        }
        else
        {
            transform.Translate(direction.normalized * distanceByFrame, Space.World);
            Quaternion rotationToNode = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationToNode, Time.deltaTime*speed);
        }
    }

    void BaseReached()
    {
		if (this.gameObject.tag != "Boss") {
			GameObject.FindObjectOfType<InventoryController> ().lives -= damage;
			//better implementation
			Destroy (gameObject);
		}
		if (this.gameObject.tag == "Boss") {
			FindObjectOfType<InventoryController> ().GameOver ();
		}
    }

    public void TakeDamage(float damage)
    {
        Healthbar.fillAmount = CurrentHealth / health;

        WTFPLS = CurrentHealth / health;
        Debug.Log(WTFPLS);

        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
		if (this.gameObject.name != "Enemy_Boss(Clone)") 
		{	
			GameObject.FindObjectOfType<InventoryController> ().currency += curValue;
			Instantiate (DeathEffect);
			Destroy(gameObject);
		}
		if (this.gameObject.tag == "Boss") {
			FindObjectOfType<InventoryController> ().VictoryMenu ();
			Destroy(gameObject);
		}
    }
}
