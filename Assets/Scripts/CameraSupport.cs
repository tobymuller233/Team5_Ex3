using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSupport : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mTheCamera = null;
    void Awake(){
        mTheCamera = gameObject.GetComponent<Camera>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
