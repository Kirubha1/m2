using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTransform : MonoBehaviour
{
    public Rigidbody rb;
    public double forceAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.forward * (float)forceAmount, ForceMode.Impulse);
    }
}


