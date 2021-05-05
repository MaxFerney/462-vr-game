using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperScripts : MonoBehaviour
{
    public static void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(value);

            SetActiveAllChildren(child, value);
        }
    }

    

}
