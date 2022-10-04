using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class fightingHandler : MonoBehaviour
{   
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerOneHPUI;
    public TextMeshProUGUI playerTwoHPUI;

    public Button specialOne;
    public Button specialTwo;

    public int playerOneHP;
    public int playerTwoHP;

    // VIDEO CLIPS / SOURCE
    public VideoPlayer idleAnimSr;
    public VideoPlayer attackSr;
    public GameObject rawAttack;

    public VideoClip idle;
    // PLAYER ONE
    public VideoClip p1LowKick;
    public VideoClip p1HighKick;
    public VideoClip p1LowPunch;
    public VideoClip p1HighPunch;
    public VideoClip p1Special;

    public VideoClip p2LowKick;
    public VideoClip p2HighKick;
    public VideoClip p2LowPunch;
    public VideoClip p2HighPunch;
    public VideoClip p2Special;

    // MISSED ATK CLIPS

    public VideoClip mp1LowKick;
    public VideoClip mp1HighKick;
    public VideoClip mp1LowPunch;
    public VideoClip mp1HighPunch;
    public VideoClip mp1Special;

    public VideoClip mp2LowKick;
    public VideoClip mp2HighKick;
    public VideoClip mp2LowPunch;
    public VideoClip mp2HighPunch;
    public VideoClip mp2Special;

    void Awake()
    {
        playerOneName.text = variableHandler.vPasser.playerName1;
        playerTwoName.text = variableHandler.vPasser.playerName2;
        playerOneHP = variableHandler.vPasser.playerHealth;
        playerTwoHP = variableHandler.vPasser.playerHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        idleAnimSr.gameObject.GetComponent<VideoPlayer>().clip = idle;
        idleAnimSr.gameObject.GetComponent<VideoPlayer>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        playerOneHPUI.text = playerOneHP + "";
        playerTwoHPUI.text = playerTwoHP + "";
        StartCoroutine(healthChecker());
    }

    public void dealDamage(int playerNum, int playerHP, int damage)
    {
        if (playerNum == 1)
            {
                playerHP -= damage;
                playerTwoHP = playerHP;
                rawAttack.SetActive(false);
            }

        else
            {
                playerHP -= damage;
                playerOneHP = playerHP;
                rawAttack.SetActive(false);
            }
    }

    // PLAYER ONE BUTTON ATTACKS
    public void playerOneLowPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowPunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        rawAttack.SetActive(true);
        StartCoroutine(delayProcess(1,75,1));
        Debug.Log("clack");
    }

    public void playerOneHighPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighPunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,55,2));
        Debug.Log("clack");
    }

    public void playerOneLowKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowKick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,65,3));
        Debug.Log("clack");
    }

    public void playerOneHighKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighKick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,45,4));
        Debug.Log("clack");
    }

    public void playerOneSpecial()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1Special;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,90,5));
        specialOne.interactable = false;
        Debug.Log("clack");
    }
    
    // PLAYER TWO BUTTON ATTACKS

    public void playerTwoLowPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowPunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,75,1));
        Debug.Log("clack");
    }

    public void playerTwoHighPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighPunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,55,2));
        Debug.Log("clack");
    }

    public void playerTwoLowKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowKick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,65,3));
        Debug.Log("clack");
    }

    public void playerTwoHighKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighKick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,45,4));
        Debug.Log("clack");
    }

    public void playerTwoSpecial()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2Special;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,90,5));
        specialTwo.interactable = false;
        Debug.Log("clack");
    }

    public IEnumerator delayProcess(int playerNumber, int accuracy,int attackNumber)
    {   
        int x = Random.Range(0,101);
        // PLAYER 1 ATK AND MISS
        if (playerNumber == 1)
        {   
            if (x <= accuracy)
            {
                    switch (attackNumber)
                    {
                    case 1:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowPunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    dealDamage(1,playerTwoHP,3);
                    Debug.Log("ting");
                    break;

                    case 2:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighPunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    dealDamage(1,playerTwoHP,8);
                    break;

                    case 3:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowKick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    dealDamage(1,playerTwoHP,6);
                    break;

                    case 4:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighKick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    dealDamage(1,playerTwoHP,12);
                    break;

                    case 5:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1Special;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(5);
                    dealDamage(1,playerTwoHP,25);
                    break;
                }
            }

            // miss p1
            else
            {
                switch (attackNumber)
                {
                    case 1:
                    Debug.Log("ting");
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1LowPunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    rawAttack.SetActive(false);
                    break;

                    case 2:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1HighPunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    rawAttack.SetActive(false);
                    break;

                    case 3:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1LowKick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    rawAttack.SetActive(false);
                    break;

                    case 4:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1HighKick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    rawAttack.SetActive(false);
                    break;

                    case 5:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1Special;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(5);
                    rawAttack.SetActive(false);
                    break;
                }
            }
        }
        // PLAYER 2 ATK AND MISS
        else
        {
           if (x <= accuracy)
                {
                    switch (attackNumber)
                    {
                        case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowPunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(2,playerOneHP,3);
                        break;

                        case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighPunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(2,playerOneHP,8);
                        break;

                        case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowKick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(2,playerOneHP,6);
                        break;

                        case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighKick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(2,playerOneHP,12);
                        break;

                        case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2Special;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        dealDamage(2,playerOneHP,25);
                        break;
                    }
                }
            // MISS p2
            else
                {
                    switch (attackNumber)
                    {
                        case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2LowPunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                        case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2HighPunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                        case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2LowKick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                        case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2HighKick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                        case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2Special;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        rawAttack.SetActive(false);
                        break;
                    }
                }
          

        }
    }

    IEnumerator healthChecker()
    {
        if (playerOneHP <= 0)
        {
            variableHandler.vPasser.winner = 2;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }

        if (playerTwoHP <= 0)
        {
            variableHandler.vPasser.winner = 1;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }

    }

}
                

    


 
    

    
