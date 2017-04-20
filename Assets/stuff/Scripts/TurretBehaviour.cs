using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{

    public Transform turretTransform;
    public GameObject projectPrefab;

    public int cost;

    public float range;
    public float distFromEnemy;
    public float atkCoolDown;
    public float atkCoolDownLeft;

    public float damage;
    public float radius;

    // Use this for initialization
    void Start() {
        turretTransform = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyBehaviour[] enemies = GameObject.FindObjectsOfType<EnemyBehaviour>();
        EnemyBehaviour closestEnemy = null;

        float dist = Mathf.Infinity;
        foreach (EnemyBehaviour enemy in enemies)
        {
            distFromEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (closestEnemy == null || distFromEnemy < dist)
            {

                closestEnemy = enemy;

                distFromEnemy = Vector3.Distance(enemy.transform.transform.position, this.transform.position);
                if (closestEnemy == null || distFromEnemy < dist)
                {
                    closestEnemy = enemy;

                    dist = distFromEnemy;
                }
            }
            if (closestEnemy == null)
            {
                return;
            }
            atkCoolDownLeft -= Time.deltaTime;
            if (distFromEnemy <= range)
            {
                Vector3 dirRot = closestEnemy.transform.position - this.transform.position;

                Quaternion lookRot = Quaternion.LookRotation(dirRot);
                turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);


                if (atkCoolDownLeft <= 0 && dirRot.magnitude <= range)
                {
                    atkCoolDownLeft = atkCoolDown;
                    ShootEnemy(closestEnemy);
                }
            }

            
        }
    }

    public void ShootEnemy(EnemyBehaviour closestEnemy)
    {
        GameObject projectileObj = (GameObject)Instantiate(projectPrefab, this.transform.position, this.transform.rotation);

        Projectile p = projectileObj.GetComponent<Projectile>();
        p.target = closestEnemy.transform;
        p.proDamage = damage;
        p.radius = radius;
    }
}
