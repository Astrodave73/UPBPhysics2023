using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderFriction : MonoBehaviour
{

    public Slider slider;
    public TMP_Text textToUpdateFriction;
    public PhysicMaterial phymat;
    public string defaultText;

    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<GameObject>();
        phymat.staticFriction = 0;
        phymat.dynamicFriction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFrictionText();
    
    }
    public void UpdateFrictionText()
    {
       
            textToUpdateFriction.text = defaultText+ slider.value.ToString("F1");
    }
    public void ChangePhysicMatUe()
    {
     phymat.staticFriction = slider.value;
    }
    public void ChangePhysicsMatUd()
    {
        phymat.dynamicFriction = slider.value;
    }
}
