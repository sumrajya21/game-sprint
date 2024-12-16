using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MovementSwitchDisk : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _diskArray;
    [SerializeField]
    private GameObject[] _diskLightsArray;
    private int _diskIndex;
    private int _diskLightsIndex;
    [SerializeField]
    private float _speed = 2f;
    private float _lBound = -20f;
    private float _rBound = 13f;

    private bool _hasFall;
    private UnifiedStorage _storage;
    public int _hits;
    public int _fallCount;

    void Start()
    {
        _hits = 0;
        _storage = this.GetComponent<UnifiedStorage>();
        _hasFall = false;
        _diskIndex = 0;
        _diskLightsIndex = _diskIndex;
        foreach (GameObject it in _diskArray) {
            it.transform.position = new Vector2(Random.Range(_lBound, _rBound), it.transform.position.y);
            it.GetComponent<BoxCollider2D>().enabled = false;
        }
        for (int i = 0; i < _diskLightsArray.Length; i++)
        {
            if (i != _diskLightsIndex)
            {
                _diskLightsArray[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
            else
            {
                _diskLightsArray[i].GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !_hasFall)
        {
            _diskLightsIndex++;
            if (_diskLightsIndex >= _diskLightsArray.Length)
            {
                _diskLightsIndex = 0;
            }
            for (int i = 0; i < _diskLightsArray.Length; i++)
            {
                if (i != _diskLightsIndex)
                {
                    _diskLightsArray[i].GetComponent<SpriteRenderer>().color = Color.black;
                    _diskArray[i].GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    _diskLightsArray[i].GetComponent<SpriteRenderer>().color = Color.blue;
                    _diskArray[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            _diskIndex = _diskLightsIndex;
        }
        if (Input.GetKey(KeyCode.A) && _diskArray[_diskIndex].transform.position.x > _lBound && !_hasFall && _diskArray[_diskIndex].GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            _diskArray[_diskIndex].transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D) && _diskArray[_diskIndex].transform.position.x < _rBound && !_hasFall && _diskArray[_diskIndex].GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            _diskArray[_diskIndex].transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _diskArray[_diskIndex].GetComponent<Rigidbody2D>().gravityScale = 1;
            _diskArray[_diskIndex].GetComponent<BoxCollider2D>().enabled = true;
            _hasFall = true;
            Invoke("SetFallFalse", 3f);
        }
        if (_hasFall == true)
        {
            _diskLightsArray[_diskLightsIndex].GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        
        if (_fallCount == 5)
        {
            _storage.TicketSet(_hits * _storage.TicketGet());
            _fallCount++;
        }
        if (Input.GetKeyDown(KeyCode.P)){
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
        Debug.Log(_storage.TicketGet() + " " + _fallCount);
        }
    }

    public void SetFallFalse()
    {
        _diskLightsArray[_diskLightsIndex].GetComponent<SpriteRenderer>().color = Color.blue;
        _hasFall = false;
    }
}
