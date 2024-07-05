using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour
{
    // Start is called before the first frame update
    private float initcolor = 0.0f;
    private bool deleted = false;
    void Awake()
    {
        initcolor = GetComponent<SpriteRenderer>().color.a;
    }

    // Update is called once per frame
    void start(){

    }
    void Update()
    {
        
    }

    private void UpdateColor(){
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        c.a -= initcolor / 4.0f;
        s.color = c;
        if(c.a <= 0.01f)
            destroy_plane(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Egg"){
            UpdateColor();
        }
        else{
            Text.touched++;
            destroy_plane(gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision){
    }

    private void destroy_plane(GameObject g){
        Destroy(g);
        Text.destroyed++;
        if(!deleted){
            GameObject gg = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
            Vector3 p = new Vector3(Random.Range(-0.9f * GreenUp.WindowWidth / 2, 0.9f * GreenUp.WindowWidth / 2), Random.Range(-90f, 90f));
            gg.transform.localPosition = p;
        }
        deleted = true;
    }
}
