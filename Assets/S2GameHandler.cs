using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class S2GameHandler : MonoBehaviour
{
    public GameObject p2Health, VideoPlayerGO;
    public int player2HP = 100;
    public VideoClip v1, v2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p2Health.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = player2HP + "";
    }
     void dealDamage(int damageAmount, int playerHP){
            playerHP -= damageAmount;
            player2HP = playerHP;
    }

    void attack(float accuracy, IEnumerator attackname, VideoClip video){
        int x = Random.Range(1, 101);

        if(x <= accuracy){
            VideoPlayerGO.gameObject.GetComponent<VideoPlayer>().clip = video;
            VideoPlayerGO.gameObject.GetComponent<VideoPlayer>().Play();
            StartCoroutine(attackname);
            Debug.Log("Attack Success!");
        }
        else{
            Debug.Log("Attack Missed!");
        }
    }
    
    public void p1Lowpunch(){
        attack(95, p1Lowpunchdelay(), v1);
    }
    public void p1Highpunch(){
        attack(75, p1Highpunchdelay(), v2);
    }
    IEnumerator p1Highpunchdelay(){
        yield return new WaitForSeconds(3F);
        dealDamage(10, player2HP);
    }
    IEnumerator p1Lowpunchdelay(){
        yield return new WaitForSeconds(2F);
        dealDamage(5, player2HP);
    }
}
