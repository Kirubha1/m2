using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingDetect : MonoBehaviour
{
    public bool landingState = false;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("landed");
        landingState = true;

    }

}
