using System;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public GameObject settings;

    public GameObject snakeElementPrefab;
    
    private int typeIdx;

    private Vector3 startPosition = new Vector3(2, 0, 0);

    private List<GameObject> snakeElements = new List<GameObject>();

    void Start()
    {

    }

    public void AddElement() {
        GameObject snakeElement;
        if (snakeElements.Count > 0) {
            snakeElement = Instantiate(snakeElementPrefab, snakeElements[snakeElements.Count-1].transform.position, Quaternion.identity, gameObject.transform);
            snakeElement.GetComponent<SnakeElement>().prev = snakeElements[snakeElements.Count-1];
            snakeElements[snakeElements.Count-1].GetComponent<SnakeElement>().next = snakeElement;
        } else {
            snakeElement = Instantiate(snakeElementPrefab, startPosition, Quaternion.identity, gameObject.transform);
        }
        snakeElements.Add(snakeElement);
        snakeElement.GetComponent<SnakeElement>().ChooseType(typeIdx);
        snakeElement.GetComponent<SnakeElement>().health = settings.GetComponent<Settings>().firstTankHealth * Mathf.Pow(settings.GetComponent<Settings>().nextTankHealthScale, snakeElements.Count-1);
    }

    public void ChooseType(int idx) {
        typeIdx = idx;
        for (int i = 0; i < settings.GetComponent<Settings>().snakeInitSize; i++) {
            AddElement();
        }
    }

    void Update()
    {
        
    }
}
