using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRemover : MonoBehaviour
{
    public GameObject PlatformRemovalPoint;

    // Start is called before the first frame update
    void Start()
    {
        //replaced GameOject with transform. may need to be changed!!
        PlatformRemovalPoint = GameObject.Find("PlatformRemovalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < PlatformRemovalPoint.transform.position.x){
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
