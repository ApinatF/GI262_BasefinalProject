using System;
using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

namespace Searching
{

    public class SkillBook : MonoBehaviour
    {
        public static SkillBook instance;
        public Inventory inventory;
        
        public SkillTree elementSkillTree;

        Skill attack; // root
        
        public Skill fireStorm;
        public Skill waterFallDance;
        public Skill earthQuake;
        
        public Skill fireStormPlus;
        public Skill waterFallDancePlus;
        public Skill earthQuakePlus;
        //Skill fireExplosion;

        public SkillTree survivalSKillltree;
        Skill baseSurvival; //root
        
        Skill passiveEnergy;
        
        Skill activeEnergy;
        

        private void Awake()
        {
            if (instance == null) instance = this;
        }


        public void Start()
        {
            #region Depicting the skill tree
            // build Element skill tree
            // └── Base Element
            //     └── FireStorm
            //            └── FireStormPlus
            //     └── WaterFallDance
            //            └── WaterFallDancePlus
            //     └── EarthQuake
            //             └── EarthQuakePlus
            #endregion
            
            
            attack = new Skill("Attack");
            attack.isAvailable = true;
            
            fireStorm = new Skill("FireStorm");
            waterFallDance = new Skill("WaterFallDance");
            earthQuake = new Skill("EarthQuake");
            
            
            fireStormPlus = new Skill("FireStormPlus");
            waterFallDancePlus = new Skill("WaterFallDancePlus");
            earthQuakePlus = new Skill("EarthQuakePlus");

            attack.nextSkills.Add(fireStorm);
            attack.nextSkills.Add(waterFallDance);
            attack.nextSkills.Add(earthQuake);
            
            fireStorm.nextSkills.Add(fireStormPlus);
            waterFallDance.nextSkills.Add(waterFallDancePlus);
            earthQuake.nextSkills.Add(earthQuakePlus);
            
            
            
            attack.Unlock();
            this.elementSkillTree = new SkillTree(attack);
            //-------------------------------------------------------------------------------
            
            #region Depicting the skill tree
            // build skill tree 
            // └── BaseSurvival
            //     └── Active energy
            //     └── Passive energy
            
            #endregion
            baseSurvival = new Skill("BaseSurvival");
            baseSurvival.isAvailable = true;
            
            activeEnergy = new Skill("ActiveEnergy");
            
            
            passiveEnergy = new Skill("PassiveEnergy");
            

            baseSurvival.nextSkills.Add(activeEnergy);
            baseSurvival.nextSkills.Add(passiveEnergy);
            
            
            baseSurvival.Unlock();
        

            this.survivalSKillltree = new SkillTree(baseSurvival);
        }

        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                elementSkillTree.rootSkill.PrintSkillTreeHierarchy("ElementSkillTree");
                //elementSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            }
            
            if (Input.GetKeyDown(KeyCode.O))
            {
                survivalSKillltree.rootSkill.PrintSkillTreeHierarchy("SurvivalSKillltree");
                //survivalSKillltree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            }

            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                attack.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                
                if (Gamemanager.instance.skillsToken > 0 && inventory.numberOfItem("FireStorm") < 0)
                {
                    if(fireStormPlus.isUnlocked) return;
                    fireStormPlus.Unlock();
                    Gamemanager.instance.skillsToken -= 1;
                    
                    Debug.Log("FireStormPlus isUnlocked");
                }
                else
                {
                    Debug.Log("FireStormBook lost in Inventory ");
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (Gamemanager.instance.skillsToken > 0 )
                {
                    if(waterFallDancePlus.isUnlocked) return;
                    waterFallDancePlus.Unlock();
                    Gamemanager.instance.skillsToken -= 1;
                    
                    Debug.Log("WaterFallDancePlus isUnlocked");
                }
                else
                {
                    Debug.Log("WaterFallDancePlus lost in Inventory ");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (Gamemanager.instance.skillsToken > 0 )
                {
                    if(earthQuakePlus.isUnlocked) return;
                    earthQuakePlus.Unlock();
                    Gamemanager.instance.skillsToken -= 1;
                    
                    Debug.Log("EarthQuakePlus isUnlocked");
                }
                else
                {
                    Debug.Log("EarthQuakePlus lost in Inventory ");
                }
                
            }
            
            ////
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Gamemanager.instance.skillsToken > 0)
                {
                    if(fireStorm.isUnlocked) return;
                    fireStorm.Unlock();
                    Gamemanager.instance.skillsToken -= 1;
                    
                    Debug.Log("FireStorm isUnlocked --> Next Level is FireStormPlus");
                }
                else
                {
                    Debug.Log("Skilll token is Low");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (Gamemanager.instance.skillsToken > 0)
                {
                    if(waterFallDance.isUnlocked) return;
                    waterFallDance.Unlock();
                    Gamemanager.instance.skillsToken -= 1;
                    
                    Debug.Log("WaterFallDance isUnlocked --> Next Level is WaterFallDancePlus");
                }
                else
                {
                    Debug.Log("Skilll token is Low");
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (Gamemanager.instance.skillsToken > 0)
                {
                    if(earthQuake.isUnlocked) return;
                    earthQuake.Unlock();
                    Gamemanager.instance.skillsToken -= 1;
                    
                    Debug.Log("EarthQuake isUnlocked --> Next Level is EarthQuakePlus");
                }
                else
                {
                    Debug.Log("Skilll token is Low");
                }
                
            }
            
        }
    }

}