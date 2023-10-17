using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuWindow : MonoBehaviour
{
    [SerializeField] private Transform menuPanel;
    float xPos;
    // Start is called before the first frame update
    void Start()
    {
        xPos = menuPanel.gameObject.transform.position.x;
        xPos = 200;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MenuOpenClose()
    {
        menuPanel.gameObject.LeanMoveLocalX(0, 1);
    }
}
