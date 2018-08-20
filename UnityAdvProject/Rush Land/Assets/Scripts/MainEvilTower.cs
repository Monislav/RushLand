using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainEvilTower : MonoBehaviour
{
    public float HP = 100;
    public Slider hpSlider;
    int dmg;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = HP;
        if (HP <= 0)
        {
            text.gameObject.SetActive(true);
            Time.timeScale = 0;
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
        if (other.gameObject.tag == ("Player"))
        {
            dmg = Random.Range(40, 80);
            HP -= dmg;
            Destroy(other.gameObject);
        }
    }
}
