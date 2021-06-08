using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityRefill : MonoBehaviour
{

    public PlayerHealth Player;


    //When player enters Collider, begin Healing
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && Player.Health < 100)
            StartCoroutine("Heal");
    }

    //When Player leaves Collider, stop Healing
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
            StopCoroutine("Heal");
    }

    IEnumerator Heal()
    {
        for (float currentHealth = Player.Health; currentHealth <= 100; currentHealth += 30 * Time.deltaTime)
        {
            Player.Health = currentHealth;
            yield return null;
        }
        Player.Health = 100f;
    }
}
