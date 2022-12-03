using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigScript : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tf;
    public double forceAmount;
    public bool hasJumped = false;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.forward * (float)forceAmount, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetButton("Jump") && !hasJumped){
            //Debug.Log("space pressed!");
            tf.Translate(0,0,5);
            hasJumped = true;
            rb.useGravity=true;
        }
        if(Input.GetButton("Fire1")){
            //Debug.Log("left ctrl pressed!");
            rb.drag = 2;
            rb.angularDrag = 1;
        }
    }
}