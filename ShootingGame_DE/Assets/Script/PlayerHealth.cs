using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip damageSound;
    public AudioClip destroySound;
    public int playerHP;
    private Slider playerHPSlider;
    public GameObject[] playerIcons;
    public static int destroyCount = 0;
    public bool isMuteki = false;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
        // これが無かったら残機数とアイコン数がずれる
        UpdatePlayerIcons();
        playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
        playerHPSlider.maxValue = playerHP;
        playerHPSlider.value = playerHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ★追加（無敵）
        // 条件文の中に「&& isMuteki == false」を追加
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false)
        {
            playerHP -= 1;
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
            playerHPSlider.value = playerHP;
            Destroy(other.gameObject);

            if (playerHP == 0)
            {
                destroyCount += 1;
                UpdatePlayerIcons();
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
                this.gameObject.SetActive(false);

                if (destroyCount < 5)
                {
                    Invoke("Retry", 1.0f);
                }
                else
                {
                    destroyCount = 0;
                    
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

    void UpdatePlayerIcons()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }

    void Retry()
    {
        this.gameObject.SetActive(true);
        playerHP = 5;
        playerHPSlider.value = playerHP;

        isMuteki = true;
        Invoke("MutekiOff", 2.0f);
    }

    void MutekiOff()
    {
        isMuteki = false;
    }

    public void AddHP(int amount)
    {
        playerHP += amount;

        if(playerHP > 10)
        {
            playerHP = 10;
        }

        playerHPSlider.value = playerHP;
    }

    public void Player1Up(int amount)
    {
        destroyCount -= amount;

        if(destroyCount < 0)
        {
            destroyCount = 0;

        }

        UpdatePlayerIcons();
    }
}