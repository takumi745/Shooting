using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cureltem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    public PlayerHealth playerHealth;
    private int reward = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Missile"))
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);

            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            Destroy(this.gameObject);

            playerHealth.AddHP(reward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
