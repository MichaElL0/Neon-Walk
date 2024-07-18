using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ifScene : MonoBehaviour
{
    private Scene AScene;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        AScene = SceneManager.GetActiveScene();
        sceneName = AScene.name;
   

        if (sceneName == "level14")
        {
            Destroy(gameObject);
        }
    }
}
