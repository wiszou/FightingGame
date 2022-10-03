using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Scene1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Scene1 scene1;
    public TMP_InputField inputField;
    public TMP_InputField inputField2;
    public string player1Name= "";
    public string player2Name = "";

    public Button button1;

    private void Awake(){

        if (scene1 == null){

            scene1 = this;
            DontDestroyOnLoad(gameObject);
            }

        else {
            Destroy(gameObject);
        }

    }


    void Update () {

    }

    public void setText(){
        player1Name = inputField.text;
        player2Name = inputField2.text;
    }

    public void changeScene(){
        StartCoroutine(delayPress());
    }

    public IEnumerator delayPress(){

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}