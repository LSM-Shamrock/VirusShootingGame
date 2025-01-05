using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    private Item item;

    private void Awake()
    {
        item = GetComponent<Item>();
        item.itemDelegate = delegate (Player player)
        {
            player.shieldTime = 10f;
        };
    }
}
