using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject projectileSpritePrefab;

    public GameObject mySnake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDestroyProjectile() {
        Destroy(gameObject);
    }

    public void SetProjectile(GameObject myParent) {
        Instantiate(projectileSpritePrefab, myParent.transform.position, Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.002f, 0);
    }
}
