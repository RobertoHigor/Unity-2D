using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Serialize para debug
    
    // Cached Reference
    SceneLoader sceneLoader;
    
    // Start is called before the first frame update
    private void Start() 
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void DecreaseBreakableBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {         
            sceneLoader.LoadNextScene();
        }
    }
}
