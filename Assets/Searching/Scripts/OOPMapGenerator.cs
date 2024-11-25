using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Searching
{

    public class OOPMapGenerator : MonoBehaviour
    {
        [Header("Set MapGenerator")]
        public int X;
        public int Y;

        [Header("Set Player")]
        public OOPPlayer player;
        public Vector2Int playerStartPos;

        [Header("Set Exit")]
        public OOPExit Exit;

        [Header("Set Prefab")]
        public GameObject[] floorsPrefab;
        public GameObject[] wallsPrefab;
        public GameObject[] demonWallsPrefab;
        public GameObject[] itemsPrefab;
        public GameObject[] keysPrefab;
        public GameObject[] enemiesPrefab;
        public GameObject[] fireStormPrefab;
        public GameObject[] waterFallDancePrefab;
        public GameObject[] earthQuakePrefab;
        public GameObject[] ApplebuffPrefab;
        public GameObject[] AppleDebuffsPrefab;
        [Header("Set Effect Prefab")]
        public GameObject[] fireStormPrefabEffect;
        public GameObject[] waterFallWaterPrefabEffect;
        public GameObject[] earthQuakePrefabEffect;

        [Header("Set Transform")]
        public Transform floorParent;
        public Transform wallParent;
        public Transform itemPotionParent;
        public Transform enemyParent;

        [Header("Set object Count")]
        public int obsatcleCount;
        public int itemPotionCount;
        public int itemKeyCount;
        public int itemFireStormCount;
        public int itemEarthQuakeCount;
        public int itemWaterFallDanceCount;
        public int itemApplebuffCount;
        public int itemAppleDebuffCount;
        public int enemyCount;
        //public int confusedFruitCount;

        public int[,] mapdata;

        public OOPWall[,] walls;
        public OOPItemPotion[,] potions;
        //public OOPconfusedFruit[,] confusedFruits;
        public OOPFireStormItem[,] fireStorms;
        public OOPEarthQuake[,] earthQuakes;
        public OOPWaterFallDance[,] waterFallDances;
        public OOPItemKey[,] keys;
        public OOPEnemy[,] enemies;
        public OOPItemBuff[,] buffs;
        public Debuff[,] debuffs;

        // block types ...
        [Header("Block Types")]
        public int playerBlock = 99;
        public int empty = 0;
        public int demonWall = 1;
        public int potion = 2;
        public int bonuesPotion = 3;
        public int exit = 4;
        public int key = 5;
        public int enemy = 6;
        public int fireStorm = 7;
        public int waterFallDance = 8;
        public int earthQuake = 9;
        public int Applebuff = 10;
        public int AppleDebuffs = 11;

        // Start is called before the first frame update
        void Start()
        {
            mapdata = new int[X, Y];
            for (int x = -1; x < X + 1; x++)
            {
                for (int y = -1; y < Y + 1; y++)
                {
                    if (x == -1 || x == X || y == -1 || y == Y)
                    {
                        int r = Random.Range(0, wallsPrefab.Length);
                        GameObject obj = Instantiate(wallsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
                        obj.transform.parent = wallParent;
                        obj.name = "Wall_" + x + ", " + y;
                    }
                    else
                    {
                        int r = Random.Range(0, floorsPrefab.Length);
                        GameObject obj = Instantiate(floorsPrefab[r], new Vector3(x, y, 1), Quaternion.identity);
                        obj.transform.parent = floorParent;
                        obj.name = "floor_" + x + ", " + y;
                    }
                }
            }

            player.mapGenerator = this;
            player.positionX = playerStartPos.x;
            player.positionY = playerStartPos.y;
            player.transform.position = new Vector3(playerStartPos.x, playerStartPos.y, -0.1f);
            mapdata[playerStartPos.x, playerStartPos.y] = playerBlock;

            walls = new OOPWall[X, Y];
            int count = 0;
            while (count < obsatcleCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == 0)
                {
                    PlaceDemonWall(x, y);
                    count++;
                }
            }

            potions = new OOPItemPotion[X, Y];
            count = 0;
            while (count < itemPotionCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceItem(x, y);
                    count++;
                }
            }

            keys = new OOPItemKey[X, Y];
            count = 0;
            while (count < itemKeyCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceKey(x, y);
                    count++;
                }
            }

            enemies = new OOPEnemy[X, Y];
            count = 0;
            while (count < enemyCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceEnemy(x, y);
                    count++;
                }
            }

            fireStorms = new OOPFireStormItem[X, Y];
            count = 0;
            while (count < itemFireStormCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceFireStorm(x, y);
                    count++;
                }
            }
            
            
            earthQuakes = new OOPEarthQuake[X, Y];
            count = 0;
            while (count < itemEarthQuakeCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceEarthQuake(x, y);
                    count++;
                }
            }
            
            waterFallDances = new OOPWaterFallDance[X, Y];
            count = 0;
            while (count < itemWaterFallDanceCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceWaterFallDance(x, y);
                    count++;
                }
            }
            buffs = new OOPItemBuff[X, Y];
            count = 0;
            while (count < itemApplebuffCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceApplebuff(x, y);
                    count++;
                }
            }
            debuffs = new Debuff[X, Y];
            count = 0;
            while (count < itemAppleDebuffCount)
            {
                int x = Random.Range(0, X);
                int y = Random.Range(0, Y);
                if (mapdata[x, y] == empty)
                {
                    PlaceDeAppleDebuff(x, y);
                    count++;
                }
            }

            mapdata[X - 1, Y - 1] = exit;
            Exit.transform.position = new Vector3(X - 1, Y - 1, 0);
        }

        public int GetMapData(float x, float y)
        {
            if (x >= X || x < 0 || y >= Y || y < 0) return -1;
            return mapdata[(int)x, (int)y];
        }

        public void PlaceItem(int x, int y)
        {
            int r = Random.Range(0, itemsPrefab.Length);
            GameObject obj = Instantiate(itemsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = itemPotionParent;
            mapdata[x, y] = potion;
            potions[x, y] = obj.GetComponent<OOPItemPotion>();
            potions[x, y].positionX = x;
            potions[x, y].positionY = y;
            potions[x, y].mapGenerator = this;
            obj.name = $"Item_{potions[x, y].Name} {x}, {y}";
        }
        
        /*public void PlaceConfusedfruit(int x, int y)
        {
            int r = Random.Range(0, itemsPrefab.Length);
            GameObject obj = Instantiate(confusedFruitPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = itemPotionParent;
            mapdata[x, y] = pconfusedFruit;
            potions[x, y] = obj.GetComponent<OOPItemPotion>(); 
            potions[x, y].positionX = x;
            potions[x, y].positionY = y;
            potions[x, y].mapGenerator = this;
            obj.name = $"Item_{potions[x, y].Name} {x}, {y}";
        }*/
        

        public void PlaceKey(int x, int y)
        {
            int r = Random.Range(0, keysPrefab.Length);
            GameObject obj = Instantiate(keysPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = itemPotionParent;
            mapdata[x, y] = key;
            keys[x, y] = obj.GetComponent<OOPItemKey>();
            keys[x, y].positionX = x;
            keys[x, y].positionY = y;
            keys[x, y].mapGenerator = this;
            obj.name = $"Item_{keys[x, y].Name} {x}, {y}";
        }

        public void PlaceEnemy(int x, int y)
        {
            int r = Random.Range(0, enemiesPrefab.Length);
            GameObject obj = Instantiate(enemiesPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = itemPotionParent;
            mapdata[x, y] = enemy;
            enemies[x, y] = obj.GetComponent<OOPEnemy>();
            enemies[x, y].positionX = x;
            enemies[x, y].positionY = y;
            enemies[x, y].mapGenerator = this;
            obj.name = $"Enemy_{enemies[x, y].Name} {x}, {y}";
        }

        public void PlaceDemonWall(int x, int y)
        {
            int r = Random.Range(0, demonWallsPrefab.Length);
            GameObject obj = Instantiate(demonWallsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = wallParent;
            mapdata[x, y] = demonWall;
            walls[x, y] = obj.GetComponent<OOPWall>();
            walls[x, y].positionX = x;
            walls[x, y].positionY = y;
            walls[x, y].mapGenerator = this;
            obj.name = $"DemonWall_{walls[x, y].Name} {x}, {y}";
        }

        public void PlaceFireStorm(int x, int y)
        {
            int r = Random.Range(0, fireStormPrefab.Length);
            GameObject obj = Instantiate(fireStormPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = wallParent;
            mapdata[x, y] = fireStorm;
            fireStorms[x, y] = obj.GetComponent<OOPFireStormItem>();
            fireStorms[x, y].positionX = x;
            fireStorms[x, y].positionY = y;
            fireStorms[x, y].mapGenerator = this;
            obj.name = $"FireStorm_{fireStorms[x, y].Name} {x}, {y}";
        }
        
        public void ShowFireStormEffect(Vector3 position)
        {
            int r = Random.Range(0, fireStormPrefabEffect.Length);
            GameObject fireStormEffect = Instantiate(fireStormPrefabEffect[r], position, Quaternion.identity);
            fireStormEffect.transform.parent = floorParent;
            Destroy(fireStormEffect, 1.5f);
        }
        
        public void TriggerFireStorm(Vector2Int[] enemyPositions)
        {
            foreach (var pos in enemyPositions)
            {
                Vector3 effectPosition = new Vector3(pos.x, pos.y, 0);
                ShowFireStormEffect(effectPosition);
            }
        }
        
        public void ShowWaterFallEffectEffect(Vector3 position)
        {
            int r = Random.Range(0, waterFallWaterPrefabEffect.Length);
            GameObject waterfallEffect = Instantiate(waterFallWaterPrefabEffect[r], position, Quaternion.identity);
            waterfallEffect.transform.parent = floorParent;
            Destroy(waterfallEffect, 1.5f);
        }
        
        public void TriggerWaterFallDance(Vector2Int[] enemyPositions)
        {
            foreach (var pos in enemyPositions)
            {
                Vector3 effectPosition = new Vector3(pos.x, pos.y, 0);
                ShowWaterFallEffectEffect(effectPosition);
            }
        }
        
        public void ShowEarthQuakeEffect(Vector3 position)
        {
            int r = Random.Range(0, earthQuakePrefabEffect.Length);
            GameObject earthQuakeEffect = Instantiate(earthQuakePrefabEffect[r], position, Quaternion.identity);
            earthQuakeEffect.transform.parent = floorParent;
            Destroy(earthQuakeEffect, 1.5f);
        }
        
        public void TriggerEarthQuakeEffect(Vector2Int[] enemyPositions)
        {
            foreach (var pos in enemyPositions)
            {
                Vector3 effectPosition = new Vector3(pos.x, pos.y, 0);
                ShowEarthQuakeEffect(effectPosition);
            }
        }
        
        public void PlaceEarthQuake(int x, int y)
        {
            int e = Random.Range(0, earthQuakePrefab.Length);
            GameObject obj = Instantiate(earthQuakePrefab[e], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = wallParent;
            mapdata[x, y] = earthQuake;
            earthQuakes[x, y] = obj.GetComponent<OOPEarthQuake>();
            earthQuakes[x, y].positionX = x;
            earthQuakes[x, y].positionY = y;
            earthQuakes[x, y].mapGenerator = this;
            obj.name = $"EarthQuake_{earthQuakes[x, y].Name} {x}, {y}";
        }
        
        public void PlaceWaterFallDance(int x, int y)
        {
            int e = Random.Range(0, waterFallDancePrefab.Length);
            GameObject obj = Instantiate(waterFallDancePrefab[e], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = wallParent;
            mapdata[x, y] = waterFallDance;
            waterFallDances[x, y] = obj.GetComponent<OOPWaterFallDance>();
            waterFallDances[x, y].positionX = x;
            waterFallDances[x, y].positionY = y;
            waterFallDances[x, y].mapGenerator = this;
            obj.name = $"WaterFallDance_{waterFallDances[x, y].Name} {x}, {y}";
        }
        public void PlaceApplebuff(int x, int y)
        {
            
            int e = Random.Range(0, ApplebuffPrefab.Length);
            GameObject obj = Instantiate(ApplebuffPrefab[e], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = wallParent;
            mapdata[x, y] = Applebuff;
            buffs[x, y] = obj.GetComponent<OOPItemBuff>();
            buffs[x, y].positionX = x;
            buffs[x, y].positionY = y;
            buffs[x, y].mapGenerator = this;
            obj.name = $"Applebuff_{buffs[x, y].Name} {x}, {y}";
            
        }
        public void PlaceDeAppleDebuff(int x, int y)
        {

            int e = Random.Range(0, AppleDebuffsPrefab.Length);
            GameObject obj = Instantiate(AppleDebuffsPrefab[e], new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = wallParent;
            mapdata[x, y] = AppleDebuffs;
            debuffs[x, y] = obj.GetComponent<Debuff>();
            debuffs[x, y].positionX = x;
            debuffs[x, y].positionY = y;
            debuffs[x, y].mapGenerator = this;
            obj.name = $"AppleDebuff_{buffs[x, y].Name} {x}, {y}";

        }




        public OOPEnemy[] GetEnemies()
        {
            List<OOPEnemy> list = new List<OOPEnemy>();
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    list.Add(enemy);
                }
            }
            return list.ToArray();
        }

        public void MoveEnemies()
        {
            List<OOPEnemy> list = new List<OOPEnemy>();
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    list.Add(enemy);
                }
            }
            foreach (var enemy in list)
            {
                enemy.MoveTowardsPlayer();
            }
        }
    }
}