using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizzil : MonoBehaviour
{
    [SerializeField] private int damage;
    private float velocity = 40f;
    public Enemy target { get; set; }
    void Start() {
        DestroyTimer(10);  
    }
    void Update()
    {
        Move();
        if (target != null) {
            ChangeDirection(target);
        }
    }
    void Move() {
        Vector3 posicaoAtual = transform.position;
        Vector3 forward = transform.forward;
        Vector3 step = forward * velocity * Time.deltaTime;
        transform.position = posicaoAtual + step;
    }
    void ChangeDirection(Enemy target) {
        Vector3 missileDirection = transform.position;
        Vector3 enemyDirection = target.transform.position;
        Vector3 newDirection = enemyDirection - missileDirection;
        transform.rotation = Quaternion.LookRotation(newDirection);
    }   
    void OnTriggerEnter(Collider elementCollided) {
        if (elementCollided.CompareTag("Enemy")) {
            Destroy(this.gameObject);
            Enemy inimigo = elementCollided.GetComponent<Enemy>();
            inimigo.ReceiveDamage(damage);
        }        
    }
    void DestroyTimer(int time) {
        Destroy(this.gameObject, time);
    }
}
