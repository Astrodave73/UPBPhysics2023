using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{

    public float rotationSpeed;
    private Transform helix;
    // Start is called before the first frame update
    void Start()
    {
        helix= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        helix.transform.Rotate(0, rotationSpeed * Time.deltaTime,0);
    }
}
