using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(GameObject.Find("Destination").transform.position);
    }
    public void ReceiveDamage(int dmg) {
        hp -= dmg;
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }
}
