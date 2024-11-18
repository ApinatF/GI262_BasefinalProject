using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

namespace Tree
{

    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill attack; // root
        
        Skill fireStorm;
        Skill waterFallDance;
        Skill earthQuake;
        
        Skill fireBall;
        Skill fireBlast;
        Skill fireWave;
        Skill fireExplosion;

        public SkillTree survivalSKillltree;
        Skill adrenalinbe; //root
        
        Skill attackBoost;
        Skill attackboostplus;

        Skill charge;
        
        
        
        
        

        public void Start()
        {
            #region Depicting the skill tree
            // build skill tree
            // └── Attack
            //     └── FireStorm
            //         ├── FireBlast
            //         └── FireBall
            //             └── FireWave
            //                 └── FireExplosion
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
            //-------------------------------------------------------------------------------
        

            this.attackSkillTree = new SkillTree(attack);
        }

        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                attackSkillTree.rootSkill.PrintSkillTreeHierarchy("AttackSkillTree");
                attackSkillTree.rootSkill.PrintSkillTree();
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
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                fireStorm.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                waterFallDance.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                earthQuake.Unlock();
            }
            
        }
    }

}