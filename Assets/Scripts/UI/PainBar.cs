using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PainBar : MonoBehaviour
{
    [SerializeField] private Transform barFill;
    [SerializeField] private TextMeshProUGUI barText;

    private void Update()
    {
        barFill.localScale = new Vector3((float)Stage.currentPain / Stage.maxPain, 1f, 1f);
        barText.text = $"Pain : {Stage.currentPain} / {Stage.maxPain}";
    }
}
