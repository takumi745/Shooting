using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    public GameObject shieldPrefab;
    private GameObject player;
    private Vector3 pos;

    //=============================================================
    //自機のミサイルでアイテムを破壊したときにシールドを生成する
    //==============================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            //effect生成
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            //Sound生成
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            
            player = GameObject.FindWithTag("Player");
            pos = player.transform.position;

            // シールド生成 
            GameObject shieldA = Instantiate(shieldPrefab, new Vector3(pos.x - 1.0f, pos.y, pos.z), Quaternion.Euler(90f, 0f, 0f));
            GameObject shieldB = Instantiate(shieldPrefab, new Vector3(pos.x + 1.0f, pos.y, pos.z), Quaternion.Euler(90f, 0f, 0f));

            shieldA.transform.SetParent(player.transform);
            shieldB.transform.SetParent(player.transform);

          
            Destroy(shieldA, 5);
            Destroy(shieldB, 5);

            
            Destroy(gameObject);
        }
    }
}