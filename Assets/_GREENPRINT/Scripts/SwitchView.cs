using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    public Vector3 realtimePosition;
    public Vector3 buildModePosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildMode()
    {
        transform.position = buildModePosition;
        transform.eulerAngles = new Vector3(0,0,0);
    }

    public void RealtimeMode()
    {
        transform.position = realtimePosition;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
