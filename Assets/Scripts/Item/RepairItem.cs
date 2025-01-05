using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairItem : MonoBehaviour
{
    private Item item;

    private void Awake()
    {
        item = GetComponent<Item>();
        item.itemDelegate = delegate (Player player)
        {
            player.remainHP += 20;
            if (player.remainHP > player.maxHP)
                player.remainHP = player.maxHP;
        };
    }
}
