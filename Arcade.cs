using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arcade : MonoBehaviour
{
    public GameObject indicator;
    public bool isBreaking = false;     //Check to see if the the arcade is being broken
    public bool isPlaying = false;      //Check to see if the arcade is being played
    public bool isBroken = false;       //Check to see if the arcade is broken
    public GameObject brokenMachine;    //Broken Machine when isBroken is true
    public GameObject machine;          //Normal machine
    public string gameName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (indicator.activeSelf && Input.GetKeyDown(KeyCode.Space) && !isPlaying && !isBroken)     //If near the machine and space is pressed and currently not playing any game and the arcade is not broken
        {
            Debug.Log("Breaking");
            isBreaking = true;
            Invoke("Breaking", 3);
        }

        else if(!isBreaking && !isBroken && indicator.activeSelf && Input.GetKeyDown(KeyCode.E))        //If near the machine and E is pressed and currently not breaking and the arcade is not broken
        {
            isPlaying = true;
            SceneManager.LoadScene(gameName);
        }

        if (isBroken)
        {
            
            brokenMachine.SetActive(true);
            machine.SetActive(false);
            indicator.SetActive(false);
            
        }

        //Debug.Log(isBreaking);
    }




    public void Breaking()
    {
        isBreaking = false;
        isBroken = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isBroken)
        {
            indicator.SetActive(true);
            
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isBreaking && collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<PlayerScript>().breaking = true;
        }
        if (isBroken && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().breaking = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicator.SetActive(false);
            other.gameObject.GetComponent<PlayerScript>().breaking = false;
        }
    }
}
