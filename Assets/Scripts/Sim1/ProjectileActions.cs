using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileActions : MonoBehaviour
{

    [SerializeField] TMP_Text speedTextWhenDestroyed;
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barco")
        {
            speedTextWhenDestroyed.text = "Barco Destruido";
        }
    }
}
