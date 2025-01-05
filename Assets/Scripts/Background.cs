using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float scrollSpeed = 8f;

    private void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y < -20)
            transform.Translate(Vector3.up * 40);
    }
}
