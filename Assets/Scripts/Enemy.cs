using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] int _lives = 2;
    private Transform[] _waypoints;
    private int _currentWaypoint;
    private Vector3 _previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        _waypoints = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>()._waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        _previousPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
        transform.LookAt(_previousPosition);
        if(transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint++;
            if (_currentWaypoint >= _waypoints.Length) 
            {
                GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().Enemies.Remove(this);
                Destroy(gameObject);
            }
        }
    }

    public void Hit()
    {
        _lives--;
        if( _lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
