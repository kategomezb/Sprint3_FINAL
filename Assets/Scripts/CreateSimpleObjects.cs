using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSimpleObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        }
    }
}
