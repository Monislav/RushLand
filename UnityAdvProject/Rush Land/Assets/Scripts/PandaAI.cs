using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;
using UnityEngine.UI;

public class PandaAI : MonoBehaviour {
    public GameObject target;
    NavMeshAgent nav;
    public GameObject partical;
    public GameObject firepos;
    public int HP = 2;
    public GameObject returnToBase;
    Animator anim;
    int i = 0;
    int dmg;
    public Slider slider;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        slider.value = HP;
    }
    [Task]
    public void Destination()
    {
        if (HP >= 100)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("SecAttack", false);
            anim.SetBool("Run", true);
            nav.SetDestination(target.transform.position);
            nav.speed = 5f;
            nav.acceleration = 5f;

        }else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("SecAttack", false);
            anim.SetBool("Run", true);
            nav.SetDestination(returnToBase.transform.position);
            nav.speed = 30f;
            nav.acceleration = 15f;
            HP += 10;
        }
        if(transform.position == returnToBase.transform.position)
        {
            anim.SetBool("Run", false);
        }
        Task.current.Succeed();

    }
    [Task]
    public void TargetPlayer()
    {
        transform.LookAt(target.transform);
        var destination = Vector3.Distance(transform.position, target.transform.position);
        if (destination <= 10)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }
    [Task]
    public void Fire()
    {
        if(i < 2)
        {
            anim.SetBool("SecAttack", false);
            anim.SetBool("Attack", true);
            i++;
        }
        else if(i == 2)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("SecAttack", true);
            i = 0;
        }
        GameObject b = Instantiate(partical, firepos.transform.position, firepos.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(b.transform.forward * 500f);
        Task.current.Succeed();
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            dmg = Random.Range(40, 80);
            HP -= dmg;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("TowerBullet"))
        {
            dmg = Random.Range(20, 50);
            HP -= dmg;
            Destroy(other.gameObject);
        }
    }
}
