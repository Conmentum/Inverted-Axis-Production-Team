using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject HitEffect;

    public float speed;
    public Transform target;
    public float proDamage;
    public float radius;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dirToTarget = target.position - this.transform.localPosition;
        float distThisFrame = speed * Time.deltaTime;

        if (dirToTarget.magnitude <= distThisFrame)
        {
            if (this.gameObject.tag == "Slow")
            {
                SlowTarget();
            }
            ProjectileHit();
        }
        else
        {
            transform.Translate(dirToTarget.normalized * distThisFrame, Space.World);
            Quaternion targetRot = Quaternion.LookRotation(dirToTarget);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRot, Time.deltaTime * 5);
        }
	}

    void ProjectileHit()
    {
        if (radius == 0)
        {
            target.GetComponent<EnemyBehaviour>().TakeDamage(proDamage);
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider cc in colliders)
            {
                EnemyBehaviour e = cc.GetComponent<EnemyBehaviour>();
                if(e != null)
                {
                    e.GetComponent<EnemyBehaviour>().TakeDamage(proDamage);
                }
            }
        }
        target.gameObject.GetComponent<EnemyBehaviour>().CurrentHealth -= proDamage;
        Instantiate(HitEffect, target.transform.position, target.transform.rotation);
        Destroy(this.gameObject);
    }
    void SlowTarget()
    {
        target.GetComponent<EnemyBehaviour>().slowed = true;
    }
}
