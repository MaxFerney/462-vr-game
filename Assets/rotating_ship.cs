using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating_ship : MonoBehaviour
{
    public float rotationspeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,rotationspeed*Time.deltaTime); //transform.localRotation.eulerAngles.x

    }
}
