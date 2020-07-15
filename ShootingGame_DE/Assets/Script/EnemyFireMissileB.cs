using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissileB : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    public float missileSpeed;
    private int timeCount = 0;

    void Update()
    {
        timeCount += 1;

        if (timeCount % 60 == 0)
        {
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity) as GameObject;
            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();
            enemyMissileRb.AddForce(transform.forward * missileSpeed);
            Destroy(enemyMissile, 10.0f);
        }
       
        if (timeCount == 500)
        {
            this.gameObject.AddComponent<Rotate>().pos = new Vector3(0, 90, 0);
        }
    }
}