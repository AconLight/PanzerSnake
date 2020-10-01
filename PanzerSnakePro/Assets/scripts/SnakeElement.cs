﻿using System;
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

    public GameObject prev { get; set; }

    private List<Vector3> myPositions = new List<Vector3>();

    public int positionsNumb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChooseType(int idx) {
        UnityEngine.Debug.Log("elo");
        if (prev) {
            for (int i = 0; i < positionsNumb; i++) {
                myPositions.Add(new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0));
            }
        }
        tankPrefab = Instantiate(tankPrefabs[idx], gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
        weaponPrefab = Instantiate(weaponPrefabs[idx], gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        float r = (float)Math.Sqrt(axisX*axisX + axisY*axisY);
        if (axisX == 0f && axisY == 0f) {
            return;
        }

        if (prev) {
            myPositions.Add(new Vector3(prev.transform.localPosition.x, prev.transform.localPosition.y, 0));
        } else {

            myPositions.Add(new Vector3(gameObject.transform.localPosition.x + axisX/r * 0.02f, gameObject.transform.localPosition.y + axisY/r * 0.02f, 0));
        }
        gameObject.transform.localPosition = myPositions[0];
        myPositions.RemoveAt(0);
    }
}
