using UnityEngine;
using System.Collections.Generic;

public class bgSpawn : MonoBehaviour
{
    [SerializeField]
    private Sprite _backgroundImg;
    [SerializeField]
    private Sprite _floorImg;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _bgPrefab;
    private GameObject _bgImageObject;
    private float _bgZOffset = 5;
    private PlayerScript playerScript;
    private Transform playerTransform;

    private float _spawnX;
    private float _tileLength;
    [SerializeField]
    private List<GameObject> _activeTilesRight;

    private void Awake()
    {
        _tileLength = 24f;
        playerScript = _player.GetComponent<PlayerScript>();
        _activeTilesRight = new List<GameObject>();
        playerTransform = _player.transform;
        this.transform.position = new Vector3(playerScript.cam.transform.position.x, playerScript.cam.transform.position.y, 0 + _bgZOffset);
        _spawnX = this.transform.position.x - _tileLength;
    }

    void Start()
    {
        SpawnTile();
    }

    void Update()
    {
        if(playerTransform.position.x >= _spawnX - _tileLength * 2)
        {
            SpawnTile();
        }
        else if (playerTransform.position.x < _tileLength * (_activeTilesRight.Count - 2))
        {
            DeleteTile();
        }
    }

    private void SpawnTile(int rev = 0)
    {
        GameObject obj;
        obj = Instantiate(_bgPrefab) as GameObject;
        obj.transform.SetParent(this.transform);
        if (rev != -1) {
            obj.transform.position = Vector2.right * _spawnX;
            _spawnX += _tileLength;
            _activeTilesRight.Add(obj);
        }
    }
    private void DeleteTile(int rev = 0)
    {
        int rIndex = _activeTilesRight.Count - 1;
        if (rev != -1 && rIndex >= 0)
        {
            Destroy(_activeTilesRight[rIndex]);
            _activeTilesRight.RemoveAt(rIndex);
            _spawnX -= _tileLength;
        }
    }
}
