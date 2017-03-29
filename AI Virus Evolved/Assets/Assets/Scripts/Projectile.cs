using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public Transform target;
    public float damage;
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
            target.GetComponent<EnemyBehaviour>().TakeDamage(damage);
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);


            foreach(Collider cc in colliders)
            {
                EnemyBehaviour e = cc.GetComponent<EnemyBehaviour>();
                if(e != null)
                {
                    e.GetComponent<EnemyBehaviour>().TakeDamage(damage);
                }
            }
        }
        //add effect here
        Destroy(gameObject);
    }
}
