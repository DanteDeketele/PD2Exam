using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerPlacer : MonoBehaviour
{
    private bool _checkForPlacement;
    private int _selectedTower;
    private Camera _camera;
    private GameObject _hoveredTile;
    private GameObject _previousHoveredTile;
    [SerializeField] private GameObject _Tower1;
    [SerializeField] private GameObject _Tower2;
    private GameObject _Tower;

    [SerializeField] private GameObject _tower1Visuals;
    [SerializeField] private GameObject _tower2Visuals;
    private GameObject _towerVisuals;

    private List<Tower> _towers = new List<Tower>();
    private EnemyManager _enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _towerVisuals = _tower1Visuals;
        _Tower = _Tower1;
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
    }

    private void Update()
    {
        if (_towers.Count <= 0) return;
        foreach(var tower in _towers) 
        {
            tower.Enemies = _enemyManager.Enemies.ToArray();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _previousHoveredTile = _hoveredTile;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.tag == "Tile")
            {
                _hoveredTile = hitInfo.transform.gameObject;
                if (_hoveredTile != _previousHoveredTile)
                {
                    if (!_hoveredTile.GetComponent<Tile>().Occupied)
                    {
                        _towerVisuals.SetActive(true);
                        _towerVisuals.transform.position = _hoveredTile.transform.position + Vector3.up;
                    }
                    
                }
            }
        }
        else
        {
            _towerVisuals.SetActive(false);
            _hoveredTile = null;
        }
        if (Input.GetMouseButton(0) && _hoveredTile != null)
        {
            Tile tile = _hoveredTile.GetComponent<Tile>();
            if (!tile.Occupied)
            {
                _hoveredTile.GetComponent<Tile>().Occupied = true;
                _towers.Add( Instantiate(_Tower, _hoveredTile.transform.position + Vector3.up/2, Quaternion.identity).GetComponent<Tower>());
                _towerVisuals.SetActive(false);
            }
        }
    }

    public void SetTowerType(int type)
    {
        _selectedTower = type;
        if (_selectedTower == 0)
        {
            _towerVisuals = _tower1Visuals;
            _Tower = _Tower1;
        }
        else
        {
            _towerVisuals = _tower2Visuals;
            _Tower = _Tower2;
        }
    }
}
