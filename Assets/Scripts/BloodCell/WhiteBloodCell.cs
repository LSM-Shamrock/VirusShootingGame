using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    private BloodCell bloodCell;

    [SerializeField] private List<GameObject> itemOriginals = new List<GameObject>();

    private void Awake()
    {
        bloodCell = GetComponent<BloodCell>();
        bloodCell.downSpeed = 3f;
        bloodCell.maxHP = 60;
        bloodCell.Dead = delegate ()
        {
            if (itemOriginals.Count == 0)
                return;

            GameObject original = itemOriginals[Random.Range(0, itemOriginals.Count)];
            Vector3 position = transform.position;
            Quaternion rotation = Quaternion.Euler(Vector3.zero);

            Stage.poolManager.SpawnObject(original, position, rotation);

            return;
        };
    }
}
