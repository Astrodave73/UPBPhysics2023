using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoatMovement : MonoBehaviour
{
    public Transform barquitoIniPos;
    private Rigidbody rb;
    public float speed = 20;
    [SerializeField] Slider speedSlider;
    [SerializeField] TMP_Text speedText;
    [SerializeField] TMP_Text speedTextWhenDestroyed;
    [SerializeField] TMP_Text newTextNotification;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject effects;
    // Start is called before the first frame update
    void Start()
    {
        barquitoIniPos = GetComponent<Transform>();
        barquitoIniPos.position = new Vector3(200, 0, 0);
        rb = GetComponent<Rigidbody>();
        newTextNotification.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        explosion.gameObject.transform.position = barquitoIniPos.position;
        Vector3 forwardDirection = transform.forward *-1;

        if (speedSlider.value == 1)
        {
            rb.velocity = forwardDirection * 10;
        }
        else if (speedSlider.value == 2)
        {
            rb.velocity = forwardDirection * 20;
        }

        else if (speedSlider.value == 3)
        {
            rb.velocity = forwardDirection * 30;
        }

        speedText.text = "Rapidez del bote: " + rb.velocity.x.ToString() + "m/s";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
           // if (explosion != null) {

                explosion.gameObject.SetActive(true);
            effects.SetActive(false);
               // explosion.Play(); 
            //}
            speedTextWhenDestroyed.gameObject.SetActive(false);
            //GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            newTextNotification.gameObject.SetActive(true);
            rb.useGravity = true;
            rb.mass = 1000;
            Debug.Log("Destroyed");
        }
    }
}
