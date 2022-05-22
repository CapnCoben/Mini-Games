using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG_Weapon;


[CreateAssetMenu(fileName = "New Chest Config", menuName = "Config/Chest")]
public class Chest : ScriptableObject
{
    public List<DropChance> possibleWeapon;
    private List<DropChance> lootBag = new List<DropChance>();


    private void OnEnable()
    {
        for (int i = 0; i < possibleWeapon.Count; i++) //iterates thhrough possible weapon list
        {
            var dc = possibleWeapon[i]; //sets dc to index of list
            for (int j = 0; j < dc.count; j++) //iterates through dc list
            {
                lootBag.Add(dc); //adds however many of dc in possible weapons there are to lootbag
            }
        }
        ChooseWeapon();
    }
    public Weapon ChooseWeapon()
    {
        return lootBag[Random.Range(0, lootBag.Count)].w; //selects a random index of weapon type in lootbag
    }


    [System.Serializable]
   public class DropChance
    {
        public Weapon w;
        public int count;


    }
}
