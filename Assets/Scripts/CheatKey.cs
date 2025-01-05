using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatKey : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(0, 7, 0);
    private Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

    private void Update()
    {
        // 모든 적 죽이기
        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Enemy[] enemys = Stage.poolManager.gameObject.GetComponentsInChildren<Enemy>();
                foreach (Enemy enemy in enemys)
                {
                    if (enemy.gameObject.activeSelf)
                        enemy.remainHP = 0;
                }
            }
        }

        // 적 소환
        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) ||
                Input.GetKeyDown(KeyCode.Keypad1))
                Stage.poolManager.SpawnObject(Stage.spawner.enemyOriginals[1 - 1], spawnPosition, spawnRotation);

            if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Keypad2))
                Stage.poolManager.SpawnObject(Stage.spawner.enemyOriginals[2 - 1], spawnPosition, spawnRotation);

            if (Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Keypad3))
                Stage.poolManager.SpawnObject(Stage.spawner.enemyOriginals[3 - 1], spawnPosition, spawnRotation);
        }

        // 적혈구, 백혈구 소환
        if (Input.GetKey(KeyCode.B))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) ||
                Input.GetKeyDown(KeyCode.Keypad1))
                Stage.poolManager.SpawnObject(Stage.spawner.bloodCellOriginals[1 - 1], spawnPosition, spawnRotation);

            if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Keypad2))
                Stage.poolManager.SpawnObject(Stage.spawner.bloodCellOriginals[2 - 1], spawnPosition, spawnRotation);
        }

        // 아이템 소환
        if (Input.GetKey(KeyCode.I))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) ||
                Input.GetKeyDown(KeyCode.Keypad1))
                Stage.poolManager.SpawnObject(Stage.spawner.itemOriginals[1 - 1], spawnPosition, spawnRotation);

            if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Keypad2))
                Stage.poolManager.SpawnObject(Stage.spawner.itemOriginals[2 - 1], spawnPosition, spawnRotation);

            if (Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Keypad3))
                Stage.poolManager.SpawnObject(Stage.spawner.itemOriginals[3 - 1], spawnPosition, spawnRotation);

            if (Input.GetKeyDown(KeyCode.Alpha4) ||
                Input.GetKeyDown(KeyCode.Keypad4))
                Stage.poolManager.SpawnObject(Stage.spawner.itemOriginals[4 - 1], spawnPosition, spawnRotation);
        }
        
        // 런쳐 업그레이드 단계 변경
        if (Input.GetKey(KeyCode.L)) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) ||
                Input.GetKeyDown(KeyCode.Keypad1))
                Stage.player.launcherUpgrade = 1 - 1;

            if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Keypad2))
                Stage.player.launcherUpgrade = 2 - 1;

            if (Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Keypad3))
                Stage.player.launcherUpgrade = 3 - 1;

            if (Input.GetKeyDown(KeyCode.Alpha4) ||
                Input.GetKeyDown(KeyCode.Keypad4))
                Stage.player.launcherUpgrade = 4 - 1;

            if (Input.GetKeyDown(KeyCode.Alpha5) ||
                Input.GetKeyDown(KeyCode.Keypad5))
                Stage.player.launcherUpgrade = 5 - 1;
        }

        // 체력 게이지 변경
        if (Input.GetKey(KeyCode.H))
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) ||
                Input.GetKeyDown(KeyCode.Keypad0))
                Stage.player.remainHP = 0;

            if (Input.GetKeyDown(KeyCode.Alpha1) ||
                Input.GetKeyDown(KeyCode.Keypad1))
                Stage.player.remainHP = 1 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Keypad2))
                Stage.player.remainHP = 2 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Keypad3))
                Stage.player.remainHP = 3 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha4) ||
                Input.GetKeyDown(KeyCode.Keypad4))
                Stage.player.remainHP = 4 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha5) ||
                Input.GetKeyDown(KeyCode.Keypad5))
                Stage.player.remainHP = 5 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha6) ||
                Input.GetKeyDown(KeyCode.Keypad6))
                Stage.player.remainHP = 6 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha7) ||
                Input.GetKeyDown(KeyCode.Keypad7))
                Stage.player.remainHP = 7 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha8) ||
                Input.GetKeyDown(KeyCode.Keypad8))
                Stage.player.remainHP = 8 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.Alpha9) ||
                Input.GetKeyDown(KeyCode.Keypad9))
                Stage.player.remainHP = 9 / 10 * Stage.player.maxHP;

            if (Input.GetKeyDown(KeyCode.F))
                Stage.player.remainHP = Stage.player.maxHP;
        }

        // 고통 게이지 변경
        if (Input.GetKey(KeyCode.P))
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) ||
                Input.GetKeyDown(KeyCode.Keypad0))
                Stage.currentPain = 0;

            if (Input.GetKeyDown(KeyCode.Alpha1) ||
                Input.GetKeyDown(KeyCode.Keypad1))
                Stage.currentPain = 1 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Keypad2))
                Stage.currentPain = 2 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha3) ||
                Input.GetKeyDown(KeyCode.Keypad3))
                Stage.currentPain = 3 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha4) ||
                Input.GetKeyDown(KeyCode.Keypad4))
                Stage.currentPain = 4 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha5) ||
                Input.GetKeyDown(KeyCode.Keypad5))
                Stage.currentPain = 5 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha6) ||
                Input.GetKeyDown(KeyCode.Keypad6))
                Stage.currentPain = 6 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha7) ||
                Input.GetKeyDown(KeyCode.Keypad7))
                Stage.currentPain = 7 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha8) ||
                Input.GetKeyDown(KeyCode.Keypad8))
                Stage.currentPain = 8 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.Alpha9) ||
                Input.GetKeyDown(KeyCode.Keypad9))
                Stage.currentPain = 9 / 10 * Stage.maxPain;

            if (Input.GetKeyDown(KeyCode.F))
                Stage.currentPain = Stage.maxPain;
        }


    }
}
