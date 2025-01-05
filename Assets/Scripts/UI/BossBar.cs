using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossBar : MonoBehaviour
{
    [SerializeField] private Transform barFill;
    [SerializeField] private TextMeshProUGUI barText;

    private void Update()
    {
        if (Stage.boss == null)
        {
            barFill.gameObject.SetActive(false);
            barText.gameObject.SetActive(false);
        }
        else
        {
            barFill.gameObject.SetActive(true);
            barText.gameObject.SetActive(true);

            barFill.localScale = new Vector3((float)Stage.boss.remainHP / Stage.boss.maxHP, 1f, 1f);
            barText.text = $"Boss : {Stage.boss.remainHP} / {Stage.boss.maxHP}";
        }
    }
}
