using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLightCycle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("daylightCycle",0f , 360f);
        
    }

    void daylightCycle()
    {
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(350, -180, 0), 0.001f);
    }
}
