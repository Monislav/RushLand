using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainTowerHP : MonoBehaviour {
    public float HP = 100;
    public Slider hpSlider;
    int dmg;
    public Text text;
    float timest = 0;

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = HP;
        if(HP <= 0)
        {
            timest += Time.deltaTime;
            text.gameObject.SetActive(true);
            Time.timeScale = 0;
            if (timest >= 4f)
            {
                SceneManager.LoadScene("Menu");
            }
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
    }
}
