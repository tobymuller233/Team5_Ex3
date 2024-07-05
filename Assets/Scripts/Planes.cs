using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour
{
    // Start is called before the first frame update
    private float initcolor = 0.0f;
    private bool deleted = false;

    public GameObject theTargetWayPoint = null;
    public Vector3 theTargetPos = new Vector3(0f, 0f, 0f);

    public float distance;

    private const float mPlaneSpeed = 20.0f / 1.0f;
    private const float theRate = 0.03f / 60f;

    private bool SequenceOrder = true;          // set by default to be follow sequencing order
    void Awake()
    {
        SequenceOrder = GreenUp.SequenceOrder();
        Vector3 p = new Vector3(Random.Range(-0.9f * GreenUp.WindowWidth / 2, 0.9f * GreenUp.WindowWidth / 2), Random.Range(-90f, 90f));
        // Vector3 p = new Vector3(0f, 0f);
        transform.localPosition = p;
        initcolor = GetComponent<SpriteRenderer>().color.a;
        if(SequenceOrder){
            theTargetWayPoint = GameObject.Find("LetterA");     // find the target waypoint
        }
        else{
            // find a random waypoint between A and F
            int r = Random.Range(0, 6);
            theTargetWayPoint = GameObject.Find("Letter" + (char)(r + 65));
        }
        theTargetPos = theTargetWayPoint.transform.localPosition;
        transform.up = new Vector3(0f, 1f, 0f);
        // Debug.Log("Plane: " + theTargetWayPoint.name + " " + theTargetPos + " " + transform.localPosition + " " + transform.up);
    }

    // Update is called once per frame
    void start(){

    }
    void Update()
    {
        SequenceOrder = GreenUp.SequenceOrder();
        Vector3 p = transform.localPosition;
        distance = Vector3.Distance(p, theTargetPos);
        if(Vector3.Distance(p, theTargetPos) < 25.0f){          // change target
            if(SequenceOrder){
                char c = theTargetWayPoint.name[6];
                if(c == 'F'){
                    theTargetWayPoint = GameObject.Find("LetterA");
                }
                else{
                    theTargetWayPoint = GameObject.Find("Letter" + (char)(c + 1));
                }
            }
            else{
                int r = Random.Range(0, 6);
                theTargetWayPoint = GameObject.Find("Letter" + (char)(r + 65));
            }
            theTargetPos = theTargetWayPoint.transform.localPosition;
        }

        PointAtPosition(theTargetPos, theRate);
        p += transform.up * (mPlaneSpeed * Time.smoothDeltaTime);
        transform.localPosition = p;
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
        if(gameObject.activeSelf == false)
        {
            return;
        }
        if(collision.gameObject.tag == "Egg"){
            if(collision.gameObject.GetComponent<Eggs>().touched){
                Debug.Log("Plane: OnTriggerEnter2D");
                return;
            }
            Text.EggCount--;
            collision.gameObject.GetComponent<Eggs>().touched = true;
            Destroy(collision.gameObject);
            UpdateColor();
            
        }
        else if(collision.gameObject.tag == "Letter")
            return;
        else{
            Text.touched++;
            gameObject.SetActive(false);
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
        }
        deleted = true;
    }

    private void PointAtPosition(Vector3 p, float rate){
        Vector3 pos = transform.localPosition;
        Vector3 v = p - pos;
        if(Vector3.Angle(v, transform.up) > 175f){
            transform.Rotate(transform.forward, 90f);
        }
        transform.up = Vector3.LerpUnclamped(transform.up, v, rate);
    }
}
