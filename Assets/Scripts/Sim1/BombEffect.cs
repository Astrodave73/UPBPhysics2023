using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;

    private void OnTriggerEnter(Collider other)
   
    {
        if(other.gameObject.CompareTag("water"))
        {
            particles.Play();
        }
    }
}
