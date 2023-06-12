using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingTurret : TowerTurret
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _barrelPivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot(Transform direction)
    {
        _barrelPivot.transform.LookAt(direction);
        GameObject go = Instantiate(_bulletPrefab, _barrelPivot.transform.position, Quaternion.identity);
        go.transform.LookAt(direction);
        go.transform.position = _barrelPivot.transform.position;
    }
}
