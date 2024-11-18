using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Gamemanager : MonoBehaviour
{

    private float hp;
    private float sp;
    public TextMeshProUGUI energyUi;
    public TextMeshProUGUI healthUi;
    // Start is called before the first frame update
    void Start()
    {
       /* GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            OOPPlayer oopPlayer = playerObj.GetComponent<OOPPlayer>();
            hp = oopPlayer.currentHeaith;
        }
        //CoinPointUi.text = $"= {curCoins.ToString()}";
    
        healthUi.text = $"= {hp.ToString()}"; */
    }

    // Update is called once per frame
    void Update()
    {
        /*GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            OOPPlayer oopPlayer = playerObj.GetComponent<OOPPlayer>();
            hp = oopPlayer.currentHeaith;
            
            healthUi.text = $"= {hp.ToString()}";
        }*/
        SetplayerUI();
    }

    private void SetplayerUI()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            OOPPlayer oopPlayer = playerObj.GetComponent<OOPPlayer>();
            hp = oopPlayer.currentHeaith;
            sp = oopPlayer.energy;


        }
        energyUi.text = $"SP= {sp.ToString()}";
    
        healthUi.text = $"HP= {hp.ToString()}";
    }
}
