using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    private GameObject fireMissilepod1;
    private GameObject fireMissilepod2;

    // Start is called before the first frame update
    void Start()
    {
        fireMissilepod1 = GameObject.Find("FireMissileB");
        fireMissilepod2 = GameObject.Find("FireMissileC");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Missile"))
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);

            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            this.gameObject.SetActive(false);

            fireMissilepod1.GetComponent<FireMissile>().enabled = true;
            fireMissilepod2.GetComponent<FireMissile>().enabled = true;

            Invoke("Normal", 3);
        }
    }

    void Normal()
    {
        fireMissilepod1.GetComponent<FireMissile>().enabled = false;
        fireMissilepod2.GetComponent<FireMissile>().enabled = false;

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
