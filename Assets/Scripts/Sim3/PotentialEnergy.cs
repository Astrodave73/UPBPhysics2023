using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotentialEnergy : MonoBehaviour
{

    [SerializeField] Slider potentialEnergySlider;
    [SerializeField] GameObject referenceFloorHeight;
    [SerializeField] GameObject massObject;


    // Start is called before the first frame update
    void Start()
    {
        potentialEnergySlider.value = 0;

    }

    // Update is called once per frame
    void Update()
    {
       // HeightDifference();
        potentialEnergySlider.value = HeightDifference();
        print(HeightDifference());
    }

    public float HeightDifference()
    {
      float difference= Mathf.Clamp01( massObject.transform.position.y- referenceFloorHeight.transform.position.y );
        return difference;
    }
}
