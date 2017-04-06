using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject normPathObj;
    GameObject flyingPathObj;
    public GameObject DeathEffect;
    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed;
    public int damage;
    public float health;
    public int curValue;

    // Use this for initialization
    void Start()
    {
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
        if (health <= 0)
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
        GameObject.FindObjectOfType<InventoryController>().lives -= damage;
        //better implementation
       // GameObject.FindObjectOfType<InventoryController>().LoseLife();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject.FindObjectOfType<InventoryController>().currency += curValue;
        //add death effect
        Destroy(gameObject);
    }
}
