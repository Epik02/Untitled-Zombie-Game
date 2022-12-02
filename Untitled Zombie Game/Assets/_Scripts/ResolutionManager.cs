using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        //Debug.Log("Ran Resolution");

        //Revisit and potentially merge into UI
    }


}
