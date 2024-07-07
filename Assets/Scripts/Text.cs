using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TMP_Text theText = null;
    public static string mode = "Mouse";
    public static string waypoint_mode = "Sequence";
    public static int touched = 0;
    
    public static int EggCount = 0;
    
    public static int destroyed = 0;
    void Start()
    {
        theText = GetComponent<TextMeshProUGUI>();
        // theText.text = "HERO: Drive(" + mode + ") TouchedEnemy(" + touched.ToString() + ")  EGG: OnScreen(" + EggCount.ToString() + ")   ENEMY:Count(10) Destroyed(" + destroyed.ToString() + ")"; 
        theText.text = "WAYPOINTS:(" + waypoint_mode + ") HERO: Drive(" + mode + ") TouchedEnemy(" + touched.ToString() + ")  EGG: OnScreen(" + EggCount.ToString() + ")" + ")   ENEMY:Count(10) Destroyed(" + destroyed.ToString() + ")";
    }

    // Update is called once per frame
    void Update()
    {
        theText = GetComponent<TextMeshProUGUI>();
        // theText.text = "HERO: Drive(" + mode + ") TouchedEnemy(" + touched.ToString() + ")  EGG: OnScreen(" + EggCount.ToString() + ")   ENEMY:Count(10) Destroyed(" + destroyed.ToString() + ")"; 
        theText.text = "WAYPOINTS:(" + waypoint_mode + ") HERO: Drive(" + mode + ") TouchedEnemy(" + touched.ToString() + ")  EGG: OnScreen(" + EggCount.ToString() + ")" + ")   ENEMY:Count(10) Destroyed(" + destroyed.ToString() + ")";
    }
}
