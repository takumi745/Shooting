using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissile : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    public float missileSpeed;
    private int timeCount = 0;

    void Update()
    {
        timeCount += 1;

        if (timeCount % 60 == 0)
        {
            // 敵のミサイルを生成する
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            // ミサイルを飛ばす方向を決める。「forward」は「z軸」方向をさす（ポイント）
            enemyMissileRb.AddForce(transform.forward * missileSpeed);

            // ３秒後に敵のミサイルを削除する。
            Destroy(enemyMissile, 3.0f);
        }
    }
}