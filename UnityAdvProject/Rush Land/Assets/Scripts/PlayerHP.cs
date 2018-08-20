using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
    public Slider slider;
    public float HP = 2000;
    int dmg;
	
	// Update is called once per frame
	void Update ()
    {
        slider.value = HP;
        if (HP < 2000)
        {
            HP += 0.1f;
        }
        if(HP <= 0)
        {
            transform.position = new Vector3(0, 0.2f, 30f);
            HP = 2000;
        }
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == ("Bullet"))
        {
            dmg = Random.Range(5, 20);
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
