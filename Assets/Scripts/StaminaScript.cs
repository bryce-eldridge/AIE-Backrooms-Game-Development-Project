using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    [SerializeField]
    public Slider SprintBar;

    private float _Stamina = 100f; //The real value of the sprint 

    public float Stamina
    {
        get => _Stamina; // When we want to give stamina, give the real value 
        set
        {
            // When we set the sprint, update
            _Stamina = value;
            SprintBar.value = _Stamina;


            // When the player runs out of stamina, stop running
            

        }
    }
}
