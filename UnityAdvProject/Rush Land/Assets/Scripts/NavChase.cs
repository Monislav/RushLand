using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavChase : MonoBehaviour {
    NavMeshAgent nav;
    public GameObject obj;
    public GameObject firepos;
    public GameObject particle;
    Animator anim;
    float timest;
    float chektime;
	// Use this for initialization
	void Start () {
        chektime = 60;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        obj = GameObject.Find("AngelTower");
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.realtimeSinceStartup >= chektime)
        {
            nav.SetAreaCost(4, 5);
        }
        timest += Time.deltaTime;
        nav.SetDestination(obj.transform.position);
        var distance = Vector3.Distance(transform.position, obj.transform.position);
        if(distance > 20)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Running", false);
        }
        if(distance <= 20 && timest >= 2f)
        {
            transform.LookAt(obj.transform.position);
            GameObject b = Instantiate(particle, firepos.transform.position, firepos.transform.rotation);
            b.transform.LookAt(obj.transform.position);
            b.GetComponent<Rigidbody>().AddForce((obj.transform.position - b.transform.position) * 100f);
            timest = 0;
        }
	}
}
