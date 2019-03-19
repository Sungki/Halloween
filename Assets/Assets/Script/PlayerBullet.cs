using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public float speed;
    public float fireRate;

    private float distance;
    private Vector3 startPosition;
    private float fireRange = 15.0f;

    public GameObject muzzlePrefeb;
  //  public GameObject hitPrefeb;

    void Start () {
        startPosition = this.transform.position;

        if (muzzlePrefeb != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefeb, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (psMuzzle != null)
                Destroy(muzzleVFX, psMuzzle.main.duration);
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
    }

    void Update () {
        transform.position += transform.forward * (speed * Time.deltaTime);
        distance = Vector3.Distance(this.transform.position, startPosition);
        if (distance >= fireRange)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision co)
    {
        if (!co.gameObject.CompareTag("Player"))
        { 
            speed = 0;
            Destroy(gameObject);
        /*            ContactPoint contact = co.contacts[0];
                    Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                    Vector3 pos = contact.point;

                    if (hitPrefeb != null)
                    {
                        var hitVfx = Instantiate(hitPrefeb, pos, rot);
                        var psHit = hitVfx.GetComponent<ParticleSystem>();
                        if (psHit != null)
                            Destroy(hitVfx, psHit.main.duration);
                        else
                        {
                            var psChild = hitVfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                            Destroy(hitVfx, psChild.main.duration);
                        }
                    }*/
        }
    }
}
