using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{

    
    [SerializeField] private string sLevelToLoad;
    public bool loadLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Fox"){
            
            SceneManager.LoadScene (sLevelToLoad);
            Time.timeScale = 1f;
        }
    }

    
}
