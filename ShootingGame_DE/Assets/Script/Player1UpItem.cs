using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UpItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip gatSound;
    public PlayerHealth playerHealth;
    private int reward = 1;

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

            AudioSource.PlayClipAtPoint(gatSound, Camera.main.transform.position);

            Destroy(this.gameObject);

            playerHealth.Player1Up(reward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
