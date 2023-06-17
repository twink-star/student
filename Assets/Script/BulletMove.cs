using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation); //oŒ»‚³‚¹‚½bulletPrefab‚ğbulllet‚É‘ã“ü
            rb = bullet.GetComponent<Rigidbody>(); //bullet‚Ìrigitbody‚ğæ“¾
            rb.AddForce(transform.forward * bulletSpeed); //‘O–Ê‚ÉŒü‚©‚Á‚Ä—Í‚ğ‰Á‚¦‚é
            Destroy(bullet, lifeTime); //bullet‚ğlifeTime•bŒã‚É‰ó‚·
        }
    }
}
