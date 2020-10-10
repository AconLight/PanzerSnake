using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject settings;

    public GameObject projectileSpritePrefab;

    public GameObject mySnake;

    private Vector2 myVelocity;

    private GameObject myParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDestroyProjectile() {
        Destroy(gameObject);
    }

    public void SetProjectile(GameObject myParent) {
        float speed = settings.GetComponent<Settings>().fireSpeed;
        this.myParent = myParent;
        Instantiate(projectileSpritePrefab, myParent.transform.position, Quaternion.identity, gameObject.transform);
        myVelocity = new Vector2(Mathf.Cos((myParent.transform.rotation.eulerAngles.z-90)*Mathf.Deg2Rad)*speed, Mathf.Sin((myParent.transform.rotation.eulerAngles.z-90)*Mathf.Deg2Rad)*speed);
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + myVelocity.x*Time.deltaTime, gameObject.transform.localPosition.y + myVelocity.y*Time.deltaTime, 0);
    }
}
