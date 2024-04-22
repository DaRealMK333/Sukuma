using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public static void BlueBeadDestroyer(int i)
    {
        Destroy(GameObject.Find("BlueBead " + (i).ToString() + "(Clone)"));
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public static void PurpleBeadDestroyer(int i )
    { 
        Destroy(GameObject.Find("PurpleBead " + (i).ToString() + "(Clone)")); 
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public static void CircleHighlightDestroyer()
    {
        Destroy(GameObject.Find("Circle Highlight(Clone)"));
    }
}
