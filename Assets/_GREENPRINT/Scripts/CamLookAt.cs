using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Transform target = Camera.main.transform;
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }
}
