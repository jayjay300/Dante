using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    GameObject Text,BattleScreen,Player;

    [SerializeField]
    string Line;

    bool Touching;
    // Start is called before the first frame update
    void Start()
    {
        Touching = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Touching == true)
        {

            switch (this.tag)
            {
                case "Item":
                    Text.SetActive(true);
                    Text.GetComponent<TMPro.TextMeshProUGUI>().text = "Obtained " + this.name;
                    break;
                case "NPC":
                    Text.SetActive(true);
                    Text.GetComponent<TMPro.TextMeshProUGUI>().text = this.name+": "+Line;
                    break;
                case "Enemy":
                    BattleScreen.SetActive(true);
                    Player.GetComponent<playerMovement>().BattleScreen(true);
                    break;
                default:
                    break;

            }
            Debug.Log("Test");
        }
    }




    private void OnTriggerStay(Collider other) {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Test");
            Text.SetActive(true);
            Text.GetComponent<TMPro.TextMeshProUGUI>().text = "Obtained "+this.name;
        }
    }

    private void OnTriggerEnter(Collider other){
        Touching = true;
    }

    private void OnTriggerExit(Collider other) {
        Touching = false;
        Text.SetActive(false);
        if (this.tag == "Enemy")
        {
            BattleScreen.SetActive(false);
            Player.GetComponent<playerMovement>().BattleScreen(false);
        }
    }
}
