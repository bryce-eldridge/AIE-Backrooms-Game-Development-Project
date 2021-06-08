using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public Slider healthBar;

    private float _health = 100f;  // The real value of the health
    public float Health
    {
        get => _health; // When we want to get health, give the player the real value
        set
        {
            //When we set the health, update the health bar
            _health = value;
            healthBar.value = _health;


            //When the player dies, Load GameOver Scene
            if (_health <= 0)
            {
                SceneManager.LoadScene(0);
            }

        }

    }

    void Start()
    {
        StartCoroutine(DrainHealth());
    }

    IEnumerator DrainHealth()
    {
        while (true)
        {
           // Perform this action forever
            Health -= Time.deltaTime * 1;
            yield return null;
        }
    }


    //When player enters Collider, Start damaging 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            StartCoroutine("Damage");
    }

    //When Player leaves Collider, stop damaging
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            StopCoroutine("Damage");
    }

    IEnumerator Damage()
    {

        for (float currentHealth = Health; currentHealth <= 100; currentHealth -= 20 * Time.deltaTime)  
        {
            Health = currentHealth;
            yield return null;
        }


    }
}
