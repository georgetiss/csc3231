using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpin : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0f, 100f * Time.deltaTime, 0f, Space.Self);

    }
}
