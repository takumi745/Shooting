using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeneEnemy());
    }

    IEnumerator GeneEnemy()
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));
                Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                enemyRb.AddForce(transform.forward * speed);
                Destroy(enemy, 10f);

                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
