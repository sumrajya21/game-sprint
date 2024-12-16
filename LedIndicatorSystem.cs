using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LedIndicatorSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _LEDArray;
    [SerializeField]
    public int _LEDIndex;

    void Start()
    {
        _LEDIndex = 0;
        foreach (GameObject it in _LEDArray)
        {
            it.GetComponent<SpriteRenderer>().color = Color.red;
        }
        LEDSelection();
    }

    void Update()
    {
        
    }

    void LEDSelection()
    {
        _LEDIndex = Random.Range(0, _LEDArray.Length);
        foreach (GameObject it in _LEDArray)
        {
            it.GetComponent<SpriteRenderer>().color = Color.red;
        }
        _LEDArray[_LEDIndex].GetComponent<SpriteRenderer>().color = Color.green;
        Invoke("LEDSelection", 3f);
    }
}
