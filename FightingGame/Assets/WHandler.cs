using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            winnerPlayer.text = VarHandler.vPasser.playerName1;
        }

        else
        {
            winnerPlayer.text = VarHandler.vPasser.playerName2;
        }
    }
}
