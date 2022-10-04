using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class winnerHandler : MonoBehaviour
{
    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;

    void Awake()
    {
        winnerNum = variableHandler.vPasser.winner;
    }
    void Start()
    {
        winnerTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winnerTitle()
    {
        if (winnerNum == 1)
        {
            winnerPlayer.text = variableHandler.vPasser.playerName1;
        }

        else
        {
            winnerPlayer.text = variableHandler.vPasser.playerName2;
        }
    }
}
