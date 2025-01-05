using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Transform barFill;
    [SerializeField] private TextMeshProUGUI barText;

    private void Update()
    {
        barFill.localScale = new Vector3((float)Stage.player.remainHP / Stage.player.maxHP, 1f, 1f);
        barText.text = $"HP : {Stage.player.remainHP} / {Stage.player.maxHP}";
    }
}
