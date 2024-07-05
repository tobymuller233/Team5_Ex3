using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    private float ScreenWidth = 200f * Screen.width / Screen.height;
    // Start is called before the first frame update
    private const float mEggSpeed = 40f / 1f;        // speed of the egg
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;
        p += transform.up * (mEggSpeed * Time.smoothDeltaTime);
        if(p.y > 100f || p.y < -100f || p.x > ScreenWidth / 2 || p.x < -ScreenWidth / 2){
            Text.EggCount--;
            Destroy(transform.gameObject);
        }
        transform.localPosition = p;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Plane"){
            Debug.Log("Egg: OnTriggerEnter2D");
            Text.EggCount--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision){

    }


}
