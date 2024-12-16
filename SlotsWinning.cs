using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotsWinning : MonoBehaviour
{

    public TMP_Text slot1;
    public TMP_Text slot2;
    public TMP_Text slot3;

    public RawImage[] _rawImages;
    public GameObject lights;

    public Texture LightOn;
    public Texture LightOff;
    // Start is called before the first frame update
    void Start()
    {
        _rawImages = lights.GetComponentsInChildren<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((slot1.text == slot2.text)  && (slot3.text == slot2.text))
        {
            foreach (RawImage image in _rawImages)
            {
                image.texture = LightOn;
                Invoke("winner", 1);
            }
        }

        else
        {
            foreach (RawImage image in _rawImages)
            {
                image.texture = LightOff;
                CancelInvoke("winner");
            }
        }
    }

    void winner()
    {
        Debug.Log("You win");
        var s = slot1.text;
        Debug.Log(s);
    }
}
