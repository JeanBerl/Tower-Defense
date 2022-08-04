using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    [SerializeField] private GameObject PrefabdoMissil;
    private GameObject pontaDoFuzil;
    void Start()
    {
        pontaDoFuzil = GameObject.Find("BazukaDaTorre");
        Instantiate(PrefabdoMissil, pontaDoFuzil.transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
