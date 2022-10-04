using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WHandler : MonoBehaviour
{
    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;

    void Awake()
    {
        winnerNum = VarHandler.vPasser.winner;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(winnerwoo());
    }
     
    IEnumerator winnerwoo()
    {
        if (winnerNum == 1)
        {
            winnerPlayer.text = VarHandler.vPasser.playerName1;
            VarHandler.vPasser.winner = 1;
            yield return new WaitForSeconds(.01f);
            SceneManager.LoadScene(3);
        }

        else
        {
            winnerPlayer.text = VarHandler.vPasser.playerName2;
            VarHandler.vPasser.winner = 2;
            yield return new WaitForSeconds(.01f);
            SceneManager.LoadScene(4);
        }
    }
}
