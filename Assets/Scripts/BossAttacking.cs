using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacking : MonoBehaviour
{
    public GameObject BossAttack1prefab;
    public float BossAttack1CD;
    private bool CanSpawn;

    // Start is called before the first frame update
    void Start()
    {
        CanSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn)
        {
            StartCoroutine(BossAttack1());
        }
    }

    IEnumerator BossAttack1()
    {
        CanSpawn = false;
        Instantiate(BossAttack1prefab, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(BossAttack1CD);
        CanSpawn = true;
        yield return null;
    }
}
