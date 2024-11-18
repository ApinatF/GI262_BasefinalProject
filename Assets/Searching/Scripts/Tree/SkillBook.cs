using System;
using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

namespace Tree
{

    public class SkillBook : MonoBehaviour
    {
        public static SkillBook instance;
        
        public SkillTree elementSkillTree;

        Skill attack; // root
        
        public Skill fireStorm;
        public Skill waterFallDance;
        Skill earthQuake;
        
        Skill fireStormPlus;
        Skill waterFallDancePlus;
        Skill earthQuakePlus;
        //Skill fireExplosion;

        public SkillTree survivalSKillltree;
        Skill baseSurvival; //root
        
        Skill attackboost;
        Skill attackboostplus;
        
        Skill healthboost;
        Skill healthboostplus;
        
        Skill charge;

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
            //            └── 
            //     └── WaterFallDance
            //            └── 
            //     └── EarthQuake
            //             └── 
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
            //     └── AttackBoost
            //     └── HealthBoost
            
            #endregion
            baseSurvival = new Skill("BaseSurvival");
            baseSurvival.isAvailable = true;
            
            healthboost = new Skill("HealthBoost");
            
            
            attackboost = new Skill("AttackBoost");
            

            baseSurvival.nextSkills.Add(attackboost);
            baseSurvival.nextSkills.Add(healthboost);
            
            
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
            if (Input.GetKeyDown(KeyCode.R))
            {
                fireStorm.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                fireStormPlus.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                waterFallDancePlus.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                earthQuakePlus.Unlock();
            }
            
            ////
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                fireStorm.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //Gamemanager.instance.skillsToken -= 1f;
                waterFallDance.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                earthQuake.Unlock();
            }
            
        }
    }

}