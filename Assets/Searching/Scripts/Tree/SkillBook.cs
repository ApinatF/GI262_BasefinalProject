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
        
        Skill fireBall;
        Skill fireBlast;
        Skill fireWave;
        Skill fireExplosion;

        public SkillTree survivalSKillltree;
        Skill adrenalinbe; //root
        
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
            // build Elemen skill tree
            // └── Attack
            //     └── FireStorm
            //     |       ├── FireBlast
            //     |       └── FireBall
            //     |           └── FireWave
            //     |               └── FireExplosion
            //     └── WaterFallDance
            //     └── EarthQuake
            #endregion
            
            
            attack = new Skill("Attack");
            attack.isAvailable = true;
            
            fireStorm = new Skill("FireStorm");
            waterFallDance = new Skill("WaterFallDance");
            earthQuake = new Skill("EarthQuake");
            
            
            fireBall = new Skill("FireBall");
            fireBlast = new Skill("FireBlast");
            fireWave = new Skill("FireWave");
            fireExplosion = new Skill("FireExplosion");

            attack.nextSkills.Add(fireStorm);
            attack.nextSkills.Add(waterFallDance);
            attack.nextSkills.Add(earthQuake);
            
            
            fireStorm.nextSkills.Add(fireBlast);
            fireStorm.nextSkills.Add(fireBall);
            fireBall.nextSkills.Add(fireWave);
            fireWave.nextSkills.Add(fireExplosion);
            
            attack.Unlock();
            this.elementSkillTree = new SkillTree(attack);
            //-------------------------------------------------------------------------------
            
            #region Depicting the skill tree
            // build skill tree
            // └── Adrenalinbe
            //     └── AttackBoost
            //     |       ├── AttackBoostPlus
            //     |       └── 
            //     └── HealthBoost;
            //     |       ├── HealthBoostPlus
            //     └── Charge;
            #endregion
            adrenalinbe = new Skill("Adrenaline");
            adrenalinbe.isAvailable = true;
            
            healthboost = new Skill("HealthBoost");
            healthboostplus = new Skill("HealthBoostPlus");
            
            attackboost = new Skill("AttackBoost");
            attackboostplus = new Skill("Attackboostplus");
            charge = new Skill("Charge");
            

            adrenalinbe.nextSkills.Add(attackboost);
            adrenalinbe.nextSkills.Add(healthboost);
            adrenalinbe.nextSkills.Add(charge);
            
            
            attackboost.nextSkills.Add(attackboostplus);
            healthboost.nextSkills.Add(healthboostplus);
            
            adrenalinbe.Unlock();
        

            this.survivalSKillltree = new SkillTree(adrenalinbe);
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
                fireBall.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                fireBlast.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                fireWave.Unlock();
            }
            
            ////
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                fireStorm.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                waterFallDance.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                earthQuake.Unlock();
            }
            
        }
    }

}