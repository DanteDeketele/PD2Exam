using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDirectionalTurret : TowerTurret
{
    [SerializeField] private Transform[] _barrles;
    [SerializeField] private GameObject _bulletPrefab;

    public override void Shoot(Transform direction)
    {
        foreach (Transform t in _barrles)
        {
            Instantiate(_bulletPrefab, t.transform.position, t.rotation);
        }
    }
}
