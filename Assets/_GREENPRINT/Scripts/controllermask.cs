using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class controllermask : MonoBehaviour
{

    public XRRayInteractor ray;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void buildmodemask()
    {
        ray.raycastMask = 224;
    }

    public void realtimemodemask()
    {
        ray.raycastMask = 96;
    }
}
