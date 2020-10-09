using System.Threading;
using System.Net.NetworkInformation;
using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeElement : MonoBehaviour
{

    public GameObject[] tankPrefabs;
    public GameObject[] weaponPrefabs;

    private GameObject tankPrefab;
    private GameObject weaponPrefab;

    public GameObject projectilePrefab;

    public GameObject prev { get; set; }
    public GameObject next { get; set; }

    public Boolean isDetached { get; set; }

    public float fireCooldown = 0.5f;

    private float canFire = 0f;

    private List<Vector3> myPositions = new List<Vector3>();

    private Vector3 prevPosition;

    public int positionsNumb;

    public int typeIdx;

    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChooseType(int idx) {
        typeIdx = idx;
        UnityEngine.Debug.Log("elo");
        if (prev) {
            for (int i = 0; i < positionsNumb; i++) {
                myPositions.Add(new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0));
            }
        }
        prevPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0);
        tankPrefab = Instantiate(tankPrefabs[idx], gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
        weaponPrefab = Instantiate(weaponPrefabs[idx], gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
    }

    private void TakeHit(int val) {
        health -= val;
        if (health <= 0) {
            OnDestroyElement();
        }
    }

    public void OnDestroyElement() {
        DetachMeAndNexts();
        Destroy(gameObject);
    }

    private void DestroyMe() {
        // TODO
    }

    public void DetachMeAndNexts() {
        if (next) {
            next.GetComponent<SnakeElement>().DetachMeAndNexts();
        }
        gameObject.transform.parent = null;
        prev = null;
        next = null;
        isDetached = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("projectile")) {
            if (gameObject.transform.parent && other.gameObject.GetComponent<Projectile>().mySnake != gameObject.transform.parent.gameObject) {
                TakeHit(20);
                other.gameObject.GetComponent<Projectile>().OnDestroyProjectile();
            }
            
        }
    }

    private void Fire() {
        if (canFire > 0 || isDetached) {
            return;
        }
        GameObject proj = Instantiate(projectilePrefab, gameObject.transform.localPosition, Quaternion.identity, null);
        proj.GetComponent<Projectile>().mySnake = gameObject.transform.parent.gameObject;
        proj.GetComponent<Projectile>().SetProjectile(gameObject);
        canFire = fireCooldown;
    }

    void Update()
    {
        canFire -= Time.deltaTime;

        if (Input.GetButton("Fire1")) {
            Fire();
        }

        Vector3 dir = gameObject.transform.localPosition - prevPosition;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 7 * Time.deltaTime);

        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        if (typeIdx != 0) {
            axisY = 0;
            axisX = 0;
        }
        float r = (float)Math.Sqrt(axisX*axisX + axisY*axisY);
        if (axisX == 0f && axisY == 0f) {
            return;
        }

        if (prev) {
            myPositions.Add(new Vector3(prev.transform.localPosition.x, prev.transform.localPosition.y, 0));
        } else if (isDetached) {
            return;
        } else {
            myPositions.Add(new Vector3(gameObject.transform.localPosition.x + axisX/r * 0.02f, gameObject.transform.localPosition.y + axisY/r * 0.02f, 0));
        }
        prevPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0);
        gameObject.transform.localPosition = myPositions[0];
        myPositions.RemoveAt(0);
    }
}
