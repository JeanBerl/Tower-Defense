using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizzil : MonoBehaviour
{
    private float velocity = 10f;
    private float timeOfLastShot;
    private float reloadTime = 1f;
    void Update()
    {
        Shoot();
    }
    void Shoot() {
        float executionTime = Time.time;
        if (executionTime > timeOfLastShot + reloadTime) {
            Debug.Log("ENTROU");
            timeOfLastShot = executionTime;
            Vector3 posicaoAtual = transform.position;
            Vector3 forward = transform.forward;
            Vector3 step = forward * velocity * Time.deltaTime;
            transform.position = posicaoAtual + step;
        }
    }
}
