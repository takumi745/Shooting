using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    // 変数の定義（データを入れるための箱を作る）
    public GameObject missilePrefab;
    public float missileSpeed;
    public AudioClip fireSound;
    private int timeCount;

    void Update()
    {
        timeCount += 1;
        if (Input.GetButton("Fire1"))
        {
            if (timeCount % 5 == 0)
            {
                // プレハブからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる。
                GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity) as GameObject;

                Rigidbody missileRb = missile.GetComponent<Rigidbody>();

                missileRb.AddForce(transform.forward * missileSpeed);

                AudioSource.PlayClipAtPoint(fireSound, transform.position);

                // 発射したミサイルを２秒後に破壊（削除）する。
                Destroy(missile, 2.0f);
            }
        }
    }
}