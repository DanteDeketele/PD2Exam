using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _lifeTime = 3f;
    [SerializeField] string _enemyTag = "Enemy";
    [SerializeField] Rigidbody _rb;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.forward*_speed*Time.deltaTime + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_enemyTag))
        {
            collision.gameObject.GetComponent<Enemy>().Hit();
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
