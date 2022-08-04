using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float timeOfLastGeneration;
    [Range(0, 3)]
    [SerializeField] private float creationReloadTime = 2.5f;
    void Update() {

        GenerateEnemy();

    }
    private void GenerateEnemy() {
        float executionTime= Time.time; 
        if (executionTime > timeOfLastGeneration+ creationReloadTime) {
            timeOfLastGeneration = executionTime;
            Vector3 generatorPosition = this.transform.position;
            Instantiate(enemy, generatorPosition, Quaternion.identity);
        }
    }
}
