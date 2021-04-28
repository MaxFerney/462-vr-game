using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(value);

            SetActiveAllChildren(child, value);
        }
    }

    

}
