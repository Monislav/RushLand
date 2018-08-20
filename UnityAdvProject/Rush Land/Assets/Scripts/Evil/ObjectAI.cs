using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour {
    Animator animator;
    public static GameObject obj;
    public GameObject GetObj()
    {
        return obj;
    }
    public GameObject partical;
    public GameObject firepos;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindClosestEnemy();
        animator.SetFloat("Distance", Vector3.Distance(transform.position, obj.transform.position));
	}

    public void Attack()
    {
        GameObject b = Instantiate(partical, firepos.transform.position, firepos.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(firepos.transform.forward * 500f);
    }
    public void StartAttack()
    {
        InvokeRepeating("Attack", 0.5f, 1f);
    }
    public void StopAttack()
    {
        CancelInvoke("Attack");
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Enemy");
        obj = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in objs)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                obj = go;
                distance = curDistance;
            }
        }
        return obj;
    }
}
