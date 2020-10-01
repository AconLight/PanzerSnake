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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChooseType(int idx) {
        UnityEngine.Debug.Log("elo");
        tankPrefab = Instantiate(tankPrefabs[idx], new Vector3(0, 0, 0), Quaternion.identity);
        weaponPrefab = Instantiate(weaponPrefabs[idx], new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
