using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mTheCamera = null;
    
    public bool mFollowMouse = true;
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f;

    public static float WindowWidth = 200f * Screen.width / Screen.height;

    // 0.2s间隔
    private float time = 0.2f;
    [SerializeField]

    void Awake(){
        for(int i = 0; i < 10; i++){
            GameObject g = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
            Vector3 p = new Vector3(Random.Range(-0.9f * WindowWidth / 2, 0.9f * WindowWidth / 2), Random.Range(-90f, 90f));
            g.transform.localPosition = p;
        }
    }
    void Start()
    {
        Debug.Assert(mTheCamera != null);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)){
            Application.Quit();
        }
        time += Time.smoothDeltaTime;
        if(time > 20f)          // in case overflow
            time = 0.2f;
        Vector3 p = transform.localPosition;
        if(Input.GetKeyDown(KeyCode.M)){        // if m is typed
            mFollowMouse = !mFollowMouse;
            if(!mFollowMouse){
                mHeroSpeed = 20f;
            }
        }

        if(mFollowMouse){
            p = mTheCamera.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;

            Text.mode = "Mouse";
        }else{
            if(Input.GetKey(KeyCode.W)){
                mHeroSpeed += 0.6f;
            }
            if(Input.GetKey(KeyCode.S)){
                mHeroSpeed -= 0.6f;
            }
            if(Input.GetKey(KeyCode.A)){
                transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
            }
            if(Input.GetKey(KeyCode.D)){
                transform.Rotate(-transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
            }
            p += (mHeroSpeed * Time.smoothDeltaTime) * transform.up;

            Text.mode = "Key";
        }
        if(Input.GetKey(KeyCode.Space) && time >= 0.2f){
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
            e.transform.localPosition = transform.localPosition;
            e.transform.up = transform.up;
            Text.EggCount++;
            time = 0.0f;
        }
        transform.localPosition = p;
    }


}
