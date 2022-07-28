using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject effect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == ("Player")){
            Debug.Log("Bum");
            gate.SetActive(false);
            Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        }
    }
}
