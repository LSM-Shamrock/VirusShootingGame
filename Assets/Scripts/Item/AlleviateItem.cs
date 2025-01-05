using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleviateItem : MonoBehaviour
{
    private Item item;

    private void Awake()
    {
        item = GetComponent<Item>();
        item.itemDelegate = delegate (Player player)
        {
            Stage.currentPain -= 20;
            if (Stage.currentPain < 0)
                Stage.currentPain = 0;
        };
    }
}
