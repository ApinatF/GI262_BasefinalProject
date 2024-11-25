using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    private float hp;
    private float sp;
    public TextMeshProUGUI energyUi;
    public TextMeshProUGUI healthUi;
    public TextMeshProUGUI TokenUi;
    
    public float ExpPoint = 0f;
    public float skillsToken = 0f;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        SetplayerUI();
    }

    private void SetplayerUI()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            OOPPlayer oopPlayer = playerObj.GetComponent<OOPPlayer>();
            hp = oopPlayer.currentHealth;
            sp = oopPlayer.energy;
        }
        
        
        
        energyUi.text = $"SP= {sp.ToString()}";
    
        healthUi.text = $"HP= {hp.ToString()}";

        TokenUi.text = $"Token ={skillsToken.ToString()}";
    }
    
    public void Gettoken(float exp)
    {
        ExpPoint += exp;
        if (ExpPoint >= 20)
        {
            skillsToken += 1f;
            ExpPoint = 0;
        }
    }
}
