using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {
    
    public GameObject obj;
    public GameObject GetObj()  
    {
        return obj;
    }
    public GameObject partical;
    public GameObject firepos;
    float timest = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        timest += Time.deltaTime;
        FindClosestEnemy();
        var distance = Vector3.Distance(transform.position, obj.transform.position);
        if (distance <= 20 && timest >= 2f)
        {
            Attack();
            timest = 0;
        }
    }

    public void Attack()
    {
        GameObject b = Instantiate(partical, firepos.transform.position, firepos.transform.rotation);
        b.transform.LookAt(obj.transform.position);
        b.GetComponent<Rigidbody>().AddForce((obj.transform.position - b.transform.position) * 100f);
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
