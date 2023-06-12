using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _fireRate;
    [SerializeField] private TowerTurret _turret;
    public Enemy[] Enemies;
    private Enemy _target;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > _fireRate)
        {
            foreach(Enemy enemy in Enemies)
            {
                if (Vector3.SqrMagnitude(transform.position - enemy.transform.position) <= _viewRadius * _viewRadius)
                {
                    _target = enemy;
                    Shoot();
                }
            }
            
        }
    }

    private void Shoot()
    {
        _time = 0;
        _turret.Shoot(_target.transform);
    }
}
