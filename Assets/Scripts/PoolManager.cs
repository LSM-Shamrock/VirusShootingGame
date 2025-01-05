using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        Stage.poolManager = this;
    }

    public GameObject SpawnObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        GameObject selectObject = null;

        if (!pools.ContainsKey(original))
        {
            pools.Add(original, new List<GameObject>());
            selectObject = Instantiate(original, position, rotation, transform);
            pools[original].Add(selectObject);
        }
        else
        {
            foreach (GameObject poolObj in pools[original])
            {
                if (poolObj.activeSelf == false)
                {
                    selectObject = poolObj;
                    selectObject.transform.position = position;
                    selectObject.transform.rotation = rotation;
                    selectObject.SetActive(true);
                    break;
                }
            }

            if (selectObject == null)
            {
                selectObject = Instantiate(original, position, rotation, transform);
                pools[original].Add(selectObject);
            }
        }

        return selectObject;
    }
}
