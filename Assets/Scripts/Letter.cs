using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    private bool hideOrNot;
    // Start is called before the first frame update
    void Start()
    {
        
        hideOrNot=false;
    }

    // Update is called once per frame
    void Update()
    {
        MakeHide();
    }
    private void MakeHide(){
        hideOrNot=!hideOrNot;
        if(Input.GetKeyDown(KeyCode.H)&&hideOrNot==true){
            HideLetter(a);
            HideLetter(b);
            HideLetter(c);
            HideLetter(d);
            HideLetter(e);
            HideLetter(f);
        }
        else if(Input.GetKeyDown(KeyCode.H)&&hideOrNot==false){
            NoHideLetter(a);
            NoHideLetter(b);
            NoHideLetter(c);
            NoHideLetter(d);
            NoHideLetter(e);
            NoHideLetter(f);
        }
    }
    private void HideLetter(GameObject gameObject){
        SpriteRenderer letterRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color c = letterRenderer.color;
        c.a = 0.0f; 
        letterRenderer.color = c;
    }
    private void NoHideLetter(GameObject gameObject){
        SpriteRenderer letterRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color c = letterRenderer.color;
        c.a = 1.0f; 
        letterRenderer.color = c;
    }
}
