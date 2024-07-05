using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool deleted = false;
    private GameObject a;
    private GameObject b;
    private GameObject c;
    private GameObject d;
    private GameObject e;
    private GameObject f;
    private Vector3 aPosition;
    private Vector3 bPosition;
    private Vector3 cPosition;
    private Vector3 dPosition;
    private Vector3 ePosition;
    private Vector3 fPosition;
    
    void Awake()
    {
        a=GameObject.Find("LetterA");
        b=GameObject.Find("LetterB");
        c=GameObject.Find("LetterC");
        d=GameObject.Find("LetterD");
        e=GameObject.Find("LetterE");
        f=GameObject.Find("LetterF");
        aPosition=a.transform.localPosition;
        bPosition=b.transform.localPosition;
        cPosition=c.transform.localPosition;
        dPosition=d.transform.localPosition;
        ePosition=e.transform.localPosition;
        fPosition=f.transform.localPosition;
    }

    // Update is called once per frame
    void start(){

    }
    void Update()
    {
        
    }

private void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.tag == "Letter"){
        if(GetComponent<Eggs>().touched){
            return;
        }
        Text.EggCount--;
        GetComponent<Eggs>().touched = true;
        Destroy(gameObject);
        SpriteRenderer letterRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        if (letterRenderer != null) {
            Color c = letterRenderer.color;
            c.a -= 0.25f; 
            letterRenderer.color = c;
            if(c.a <= 0.01f)
            ChangePosition(collision.gameObject);
        }

    }
}

    private void OnTriggerStay2D(Collider2D collision){
    }
    private void ChangePosition(GameObject gameObject){

        Vector3 p=getPosition(gameObject);
        float x=Random.Range(p.x-15,p.x+15);
        float y=Random.Range(p.y-15,p.y+15);
        gameObject.transform.localPosition=new Vector3(x,y,0);
        SpriteRenderer letterRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color currentColor = letterRenderer.color;
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
        letterRenderer.color = newColor;
    }

    private Vector3 getPosition(GameObject gameObject){
        if(gameObject.Equals(a)){
            return new Vector3(-70,70,0);
        }
        else if(gameObject.Equals(b)){
            return new Vector3(70,-70,0);
        }
        else if(gameObject.Equals(c)){
            return new Vector3(30,0,0);
        }
        else if(gameObject.Equals(d)){
            return new Vector3(-70,-70,0);
        }
        else if(gameObject.Equals(e)){
            return new Vector3(70,70,0);
        }
        else {
            return new Vector3(-30,0,0);
        }
    }
    
}

