using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{

    public Transform turretTransform;
    public GameObject projectPrefab;

    public string turretName;

    public int cost;

    public float range;
    public float distFromEnemy;
    public float atkCoolDown;
    public float atkCoolDownLeft;

    public float damage;

    // Use this for initialization
    void Start()
    {
        turretTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag != "Aerial")
        {
            EnemyBehaviour[] enemies = GameObject.FindObjectsOfType<EnemyBehaviour>();

            EnemyBehaviour closestEnemy = null;
            float dist = Mathf.Infinity;

            foreach (EnemyBehaviour e in enemies)
            {
                if (e.gameObject.tag != "Aerial")
                {
                    float d = Vector3.Distance(this.transform.position, e.transform.position);
                    if (closestEnemy == null || d < dist)
                    {
                        closestEnemy = e;
                        dist = d;
                    }
                }
            }

            if (closestEnemy == null)
            {
                return;
            }

            Vector3 dir = closestEnemy.transform.position - this.transform.position;

            Quaternion lookRot = Quaternion.LookRotation(dir);

            //Debug.Log(lookRot.eulerAngles.y);
            turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

            atkCoolDownLeft -= Time.deltaTime;
            if (atkCoolDownLeft <= 0 && dir.magnitude <= range)
            {
                atkCoolDownLeft = atkCoolDown;
                ShootEnemy(closestEnemy);
            }

        }
        if (this.gameObject.tag == "Aerial")
        {
            EnemyBehaviour[] enemies = GameObject.FindObjectsOfType<EnemyBehaviour>();

            EnemyBehaviour closestEnemy = null;
            float dist = Mathf.Infinity;

            foreach (EnemyBehaviour e in enemies)
            {
                if (e.gameObject.tag == "Aerial")
                {
                    float d = Vector3.Distance(this.transform.position, e.transform.position);
                    if (closestEnemy == null || d < dist)
                    {
                        closestEnemy = e;
                        dist = d;
                    }
                }
            }

            if (closestEnemy == null)
            {
                return;
            }

            Vector3 dir = closestEnemy.transform.position - this.transform.position;

            Quaternion lookRot = Quaternion.LookRotation(dir);

            //Debug.Log(lookRot.eulerAngles.y);
            turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

            atkCoolDownLeft -= Time.deltaTime;
            if (atkCoolDownLeft <= 0 && dir.magnitude <= range)
            {
                atkCoolDownLeft = atkCoolDown;
                ShootEnemy(closestEnemy);
            }
        }
    }

    public void ShootEnemy(EnemyBehaviour closestEnemy)
    {
        if (this.tag == "Normal")
        {
            AudioManager.Instance.PlaySound("Pew1");
        }

        if (this.tag == "Slow")
        {
            AudioManager.Instance.PlaySound("Pew2");
        }

        if (this.tag == "Fire")
        {
            AudioManager.Instance.PlaySound("Pew3");
        }

        if (this.tag == "Aerial")
        {
            AudioManager.Instance.PlaySound("Pew4");
        }

        if (this.tag == "AreaDMG")
        {
            AudioManager.Instance.PlaySound("Pew5");
        }


        GameObject projectileObj = (GameObject)Instantiate(projectPrefab, this.transform.position, this.transform.rotation);
        Projectile p = projectileObj.GetComponent<Projectile>();
        p.target = closestEnemy.transform;
        p.proDamage = damage;
    }
}