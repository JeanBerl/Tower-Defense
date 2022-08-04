using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Clickou");
        }
    }
}
