using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    [SerializeField] private GameObject PrefabdoMissil;
    private float timeOfLastShot;
    private float reloadTime = 1f;
    [SerializeField] private float attackRange;
    private GameObject pontaDoFuzil;
    void Start()
    {
        timeOfLastShot = Time.time;
        pontaDoFuzil = GameObject.Find("BazukaDaTorre");
        Instantiate(PrefabdoMissil, pontaDoFuzil.transform.position, transform.rotation);
    }

    void Update()
    {
        Enemy target = SelectTarget();
        if (target != null) {
            Shoot(target);
        }
    }
    private void Shoot(Enemy enemy) {
        float executionTime = Time.time;
        if (executionTime > timeOfLastShot + reloadTime) {
            timeOfLastShot = executionTime;
            GameObject pontoDeDisparo = this.transform.Find("BazukaDaTorre").gameObject;
            Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
            GameObject projetilObject = (GameObject)Instantiate(PrefabdoMissil, posicaoDoPontoDeDisparo, Quaternion.identity);
            Mizzil missil = projetilObject.GetComponent<Mizzil>();
            missil.target = enemy;
        }
    }
    private Enemy SelectTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            if (IsOnRange(enemy)) {
                return enemy.GetComponent<Enemy>();
            }
        }
        return null;
    }
    private bool IsOnRange(GameObject enemy) {
        Vector3 enemyPositionOnPlane = Vector3.ProjectOnPlane(enemy.transform.position, Vector3.up);
        Vector3 towerPositionOnPlane =
        Vector3.ProjectOnPlane(this.transform.position, Vector3.up);
        float distanciaParaInimigo = Vector3.Distance(towerPositionOnPlane, enemyPositionOnPlane);
        return distanciaParaInimigo < attackRange;
    }
}
