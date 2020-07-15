using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageNumber : MonoBehaviour
{
    private Text stageNumberText;

    void Start()
    {
        // 「Text」コンポーネントにアクセスして取得する。
        stageNumberText = this.gameObject.GetComponent<Text>();

        //現在のシーンの名前を取得してtextプロパティにセット
        stageNumberText.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        stageNumberText.color = Color.Lerp(stageNumberText.color, new Color(1, 1, 1, 0), 0.5f * Time.deltaTime);
    }
}