using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    private float eggTime;
    private float nowTime;
    private float maxwidth=70f;
    private float nowWidth;
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        nowWidth=0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
    }
    private float getWidth(float interval){ //得到bar的宽度
        float width=maxwidth*(0.2f-interval)*10;
        return width;
    }
    private void UpdateBar(){
        eggTime=GreenUp.GetNowTime();  //得到子弹发射的时间
        nowTime=Time.time;
        float intervalTime=nowTime-eggTime;
        if (intervalTime <= 0.2)
        {
            nowWidth = getWidth(intervalTime);
        }
        else{
            nowWidth = 0.0f;
        }
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = nowWidth;
        gameObject.transform.localScale = newScale;
    }
    
}