using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
    NavMeshAgent nav;
    Animator anim;
    public GameObject particle;
    public GameObject firepos;
    int i = 0;
    float timest = 0;
    bool cheking;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        timest += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            if(Physics.Raycast(ray, out hit))
            {
                anim.SetBool("Attacking", false);
                nav.destination = hit.point;
                nav.stoppingDistance = 0;
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Evil")
            {
                nav.stoppingDistance = 10;

                if(Vector3.Distance(transform.position, hit.point) <= 20 && timest > 1f)
                {
                        anim.SetBool("Attacking", true);
                        GameObject b = Instantiate(particle, firepos.transform.position, firepos.transform.rotation);
                        b.transform.LookAt(hit.transform.position);
                        b.GetComponent<Rigidbody>().AddForce((hit.transform.position - b.transform.position) * 100f);
                        i++;

                    timest = 0;
                }
            }
        }
        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            cheking = false;
        }
        else
        {
            cheking = true;
        }
        anim.SetBool("Running", cheking);
    }
}
