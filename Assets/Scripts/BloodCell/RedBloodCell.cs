using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
    private BloodCell bloodCell;

    private int penaltyPain = 10;

    private void Awake()
    {
        bloodCell = GetComponent<BloodCell>();
        bloodCell.downSpeed = 10f;
        bloodCell.maxHP = 40;
        bloodCell.Dead = delegate ()
        {
            Stage.currentPain += penaltyPain;
            if (Stage.currentPain > Stage.maxPain)
                Stage.currentPain = Stage.maxPain;

            return;
        };
    }
}
