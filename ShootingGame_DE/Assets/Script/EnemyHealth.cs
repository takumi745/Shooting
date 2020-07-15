using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip sound;
    public int enemyHP;
    public Slider hpSlider;
    public int scoreValue;
    private ScoreManager sm;
    public GameObject[] item; //配列
    public int nextSceneNumber;
    public AudioClip clearSound;

    private void Start()
    {
        //================================================
        //動き敵には『HPスライダー』を設置しない
        //HPスライダーを設置している敵のみ動作する
        //================================================
        if(hpSlider)
        {
            // スライダーの最大値の設定
            hpSlider.maxValue = enemyHP;

            // スライダーの現在値の設定
            hpSlider.value = enemyHP;
        }

        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            enemyHP -= 1;
            Destroy(other.gameObject);

            if (hpSlider)
            {
                // スライダーの現在値
                hpSlider.value = enemyHP;
            }

            if (enemyHP == 0)
            {
                //Destroy(transform.root.gameObject);

                //親オブジェクトを非表示にする
                transform.root.gameObject.SetActive(false);

                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

                sm.AddScore(scoreValue);

                //=========================================
                //(アイテムランダム出現)
                //アイテムの設定をしてないときは出ない
                //=========================================
                if (item.Length != 0)
                {
                    int itemNumber = Random.Range(0, item.Length);
                    Instantiate(item[itemNumber], transform.position, Quaternion.Euler(90f, 0f, 0f));
                }

                if (this.gameObject.transform.root.CompareTag("Boss"))
                {
                    AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);

                    Invoke("GoNextStage", 1);
                }
            }
        }
    }

    void GoNextStage()
    {
        SceneManager.LoadScene(nextSceneNumber);
    }
}