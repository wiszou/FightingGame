using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{
    public TextMeshProUGUI p1Name;
    public TextMeshProUGUI p2Name;

    public TextMeshProUGUI p1HPUI;
    public TextMeshProUGUI p2HPUI;

    public GameObject specialButton1;

    public GameObject specialButton2;

    public int p1HP = 100;
    public int p2HP = 100;


    public void Awake(){
        p1Name.text = Scene1.scene1.player1Name;
        p2Name.text = Scene1.scene1.player2Name;
    }

    void Update()
    {
        p1HPUI.GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + p1HP;
        p2HPUI.GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + p2HP;
    }
    

}