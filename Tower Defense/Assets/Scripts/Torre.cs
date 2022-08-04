using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    [SerializeField] private GameObject PrefabdoMissil;
    private float timeOfLastShot;
    private float reloadTime = 1f;
    private GameObject pontaDoFuzil;
    void Start()
    {
        timeOfLastShot = Time.time;
        pontaDoFuzil = GameObject.Find("BazukaDaTorre");
        Instantiate(PrefabdoMissil, pontaDoFuzil.transform.position, transform.rotation);
    }

    void Update()
    {
        Shoot();
    }
    void Shoot() {
        float executionTime = Time.time;
        if (executionTime > timeOfLastShot + reloadTime) {
            timeOfLastShot = executionTime;
            pontaDoFuzil = GameObject.Find("BazukaDaTorre");
            Instantiate(PrefabdoMissil, pontaDoFuzil.transform.position, transform.rotation);
        }
    }
}
