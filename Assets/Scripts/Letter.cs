using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private GameObject LetterParent;
    public List<Transform> LetterArray;       //遍历的结果数组

    private bool LetterMode = true; //字母是否显示 

    // Start is called before the first frame update
    void Start()
    {
        LetterParent = gameObject;   //查找物体
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosition();
        EnVisible();
         
    }

    
    private void ChangePosition() //不击毁重新生成位置
    {
        int arraylength = LetterParent.GetComponentsInChildren<Transform>(true).Length - 1;
        Color c;
        //只遍历所有的子物体，没有孙物体 ，遍历不包含本身
        foreach (Transform child in LetterParent.transform)
        {
            LetterArray.Add(child);
        }
        for(int i = 0; i < arraylength; i++)  //遍历六个字母
        {
            SpriteRenderer s = LetterArray[i].GetComponent<SpriteRenderer>();
            c = s.color;
            if(c.a < 0.0f) //如果没有颜色
            {
                LetterArray[i].transform.localPosition = RePosition(i);
            }
        }
        
        /*  测试代码
        for(int i = 0; i < arraylength; i++)
        {
            Debug.Log("遍历物体" + LetterArray[i]);
            Debug.Log(arraylength);
        }
        */
    }

    private Vector3 RePosition(int i)
    {
        float randomX = 0.0f, randomY = 0.0f;
        switch (i)
        {
            case 0:
                randomX = Random.Range(-85f,-55f);
                randomY = Random.Range(55f,85f);
                break;
            case 1:
                randomX = Random.Range(55f,85f);
                randomY = Random.Range(-85f,-55f);
                break;
            case 2:
                randomX = Random.Range(45f,15f);
                randomY = Random.Range(-15f,15f);
                break;
            case 3:
                randomX = Random.Range(-85f,-55f);
                randomY = Random.Range(-85f,-55f);
                break;
             case 4:
                randomX = Random.Range(55f,85f);
                randomY = Random.Range(55f,85f);
                break;
            default:
                randomX = Random.Range(-45f,-15f);
                randomY = Random.Range(-15f,15f);
                break;
        }
        Vector3 new_p = new Vector3(randomX, randomY, 0f);
        return new_p;
    }
    private void EnVisible()   //是否可见
    {
        int arraylength = LetterParent.GetComponentsInChildren<Transform>(true).Length - 1;
        if(Input.GetKeyDown(KeyCode.H))
        {
            LetterMode = !LetterMode;
        }
        if(LetterMode){
           for (int i = 0; i < transform.childCount; i++)
            {
                // 获取子物体并启用它们
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log("禁用物体"+ i);
            }
        }
        else{
             // 获取父物体的所有子物体
            for (int i = 0; i < transform.childCount; i++)
            {
                // 获取子物体并禁用它们
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("禁用物体"+ i);
            }
        }
    }
}