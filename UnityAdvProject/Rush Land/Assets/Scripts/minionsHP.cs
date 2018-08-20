using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minionsHP : MonoBehaviour {
    public float HP = 100;
    public Slider hpSlider;
    int dmg;

	// Update is called once per frame
	void Update ()
    {
        hpSlider.value = HP;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == ("TowerBullet"))
        {
            dmg = Random.Range(20, 50);
            HP -= dmg;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("Bullet"))
        {
            dmg = Random.Range(5, 20);
            HP -= dmg;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("Player"))
        {
            dmg = Random.Range(40, 80);
            HP -= dmg;
            Destroy(other.gameObject);
        }
    }
}
