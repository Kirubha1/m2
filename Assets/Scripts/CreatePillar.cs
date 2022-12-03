using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePillar : MonoBehaviour
{
    GameObject createPillars;
    GameObject cylinder1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFourPillars()
    {
        cylinder1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject cylinder2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject cylinder3 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject cylinder4 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        cylinder1.tag = "CreatedPillers";
        cylinder2.tag = "CreatedPillers";
        cylinder3.tag = "CreatedPillers";
        cylinder4.tag = "CreatedPillers";

        cylinder1.transform.position = new Vector3(-50f, 30f, 50f);
        cylinder2.transform.position = new Vector3(50f, 30f, 50f);
        cylinder3.transform.position = new Vector3(50f, 30f, -50f);
        cylinder4.transform.position = new Vector3(-50f, 30f, -50f);

        cylinder1.transform.localScale = new Vector3(6f, 30f, 6f);
        cylinder2.transform.localScale = new Vector3(6f, 30f, 6f);
        cylinder3.transform.localScale = new Vector3(6f, 30f, 6f);
        cylinder4.transform.localScale = new Vector3(6f, 30f, 6f);
    }

    public void ScaleFourPillars()
    {
        foreach (GameObject pillerObj in GameObject.FindGameObjectsWithTag("CreatedPillers"))
        {
            pillerObj.transform.localScale += new Vector3(0, 30f, 0);
        }
    }

    public void DestoryFourPillars()
    {
        foreach (GameObject pillerObj in GameObject.FindGameObjectsWithTag("CreatedPillers"))
        {
            Destroy(pillerObj);
        }
    }
}
