using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletprefab;
    public float SpawnRate;
    private float SpawnCooldownTime;
    private bool CanSpawn;

    // Start is called before the first frame update
    void Start()
    {
        CanSpawn = true;
    }

    // Update is called once per frame

    void Update()
    {
        /*if (SpawnCooldownTime>0)
        {
            SpawnCooldownTime -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.X) && SpawnCooldownTime<=0)
        {
            Instantiate(bulletprefab, this.transform.position, this.transform.rotation);
            SpawnCooldownTime = SpawnRate;
        }*/

        if (Input.GetKey(KeyCode.X) && CanSpawn)
        {
            StartCoroutine(SpawnBullet());
        }

    }

    IEnumerator SpawnBullet()
    {
        CanSpawn = false;
        Instantiate(bulletprefab, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(SpawnRate);
        CanSpawn = true;
        yield return null;
    }
}
