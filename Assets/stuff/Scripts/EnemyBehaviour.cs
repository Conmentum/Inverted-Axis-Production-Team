using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject normPathObj;
    GameObject flyingPathObj;
    public GameObject DeathEffect;

    public Transform EnemyTransform;

    Transform targetPathNode;
    int pathNodeIndex = 0;


    public Image Healthbar;

    [Header("Stats")]
    public float MaxSpeed;
    public float speed;
    private float slowCooldown = 3;
    public bool slowed;
    public bool DamageOverTime;
    public int damage;
    public float dps;
    public float health;
    public float CurrentHealth;
    public int curValue;
    public float time;


    // Use this for initialization
    void Start()
    {
        //Healthbar = GetComponent<Image>();
        speed = MaxSpeed;
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
        HasBeenSlowed();
        if (CurrentHealth <= 0)
        {
            Die();
            Instantiate(DeathEffect, transform.position, transform.rotation);
        }
        StartCoroutine(DPS());
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
            //this part is changed from (this.transform.rotation) to enemytransform.rotation
            EnemyTransform.rotation = Quaternion.Lerp(EnemyTransform.rotation, rotationToNode, Time.deltaTime * speed);
        }
        StartCoroutine(DPS());
    }

    void BaseReached()
    {
        if (this.gameObject.tag != "Boss")
        {
            GameObject.FindObjectOfType<InventoryController>().lives -= damage;
            //better implementation
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Boss")
        {
            FindObjectOfType<InventoryController>().GameOver();
        }
    }

    public void TakeDamage(float damage)
    {
        Healthbar.fillAmount = CurrentHealth / health;

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
            AudioManager.Instance.PlaySound("ShortExplosion");

            GameObject.FindObjectOfType<InventoryController>().currency += curValue;
            Instantiate(DeathEffect);
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Boss")
        {
            AudioManager.Instance.PlaySound("Explosion");

            FindObjectOfType<InventoryController>().VictoryMenu();
            Destroy(gameObject);
        }
    }
    public void HasBeenSlowed()
    {
        if (slowed == true)
        {
            {
                if (slowCooldown >= 0)
                {
                    slowCooldown -= Time.deltaTime;
                    speed = MaxSpeed / 2;
                }
                if (slowCooldown <= 0)
                {
                    speed = MaxSpeed;
                    slowed = false;
                    slowCooldown = 3;
                }
            }
        }
        else
        {
            return;
        }
    }
    IEnumerator DPS()
    {
        time -= Time.deltaTime;
        if (DamageOverTime == true)
        {
            if (time <= 0)
            {
                DamageOverTime = false;
            }
            if (time > 0)
            {
                TakeDamage(dps);
                yield return null;
            }
        }
    }
}
