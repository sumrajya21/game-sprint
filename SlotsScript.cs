using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SlotsScript : MonoBehaviour
{
    // Start is called before the first frame update
    char[] easyNum = { '0', '1' };
    char[] medNum = { '0', '1', '2', '3', '4' };
    char[] hardNum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    char[] Num;
    public TMP_Text slotNum;
    public float time;
    
    void Start()
    {
        slotNum = GetComponent<TMP_Text>();
        Num = hardNum;
    }

    // Update is called once per frame
    void Update()
    {
        //slotNum.text = Num[index%10].ToString();
        //index++;
        slotNum.text = Num[Random.Range(0, Num.Length)].ToString();
    }

    public void setEasy()
    {
        
        Invoke("easy", 4);
    }

    public void setMedium()
    {
        
        Invoke("medium", 4);
    }

    public void setHard()
    {
        
        Invoke("hard", 4);
    }

    public void On()
    {
        enabled = true;
        Invoke("Off", 5);
    }

    public void Off()
    {
        Invoke("DelayNum", time);
    }

    public void DelayNum()
    {
        enabled = false;
    }

    void easy()
    {
        Num = easyNum;
    }

    void medium()
    {
        Num = medNum;
    }

    void hard()
    {
        Num = hardNum;
    }

    public void exit()
    {
        SceneManager.LoadScene("MainScene");
    }
}
