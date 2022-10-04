using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pressRetry(){
        StartCoroutine(Retrydelay());
        Debug.Log("Start");
    }

    IEnumerator Retrydelay(){
        Debug.Log("Retrying the game");
        yield return new WaitForSeconds(.1f);
        Debug.Log("New Game Started");
        SceneManager.LoadScene(1);
    }
}