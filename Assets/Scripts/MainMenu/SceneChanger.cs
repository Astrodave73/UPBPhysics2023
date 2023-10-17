using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SceneChange(int index)
    {
        SceneManager.LoadScene(index);
    }
}
