using System.ComponentModel;
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

    private Vector3 startPosition = new Vector3(0, 0, 0);

    private List<GameObject> snakeElements = new List<GameObject>();

    void Start()
    {

    }

    public void AddElement() {
        snakeElements.RemoveAll(item => item == null);
        GameObject snakeElement;
        Vector3 setPosition = settings.GetComponent<Settings>().startPositions[typeIdx];
        if (snakeElements.Count > 0) {
            setPosition = snakeElements[snakeElements.Count-1].transform.localPosition;
            snakeElement = Instantiate(snakeElementPrefab, snakeElements[snakeElements.Count-1].transform.localPosition, Quaternion.identity, gameObject.transform);
            snakeElement.GetComponent<SnakeElement>().prev = snakeElements[snakeElements.Count-1];
            snakeElements[snakeElements.Count-1].GetComponent<SnakeElement>().next = snakeElement;
        } else {
            snakeElement = Instantiate(snakeElementPrefab, startPosition, Quaternion.identity, gameObject.transform);
        }
        snakeElements.Add(snakeElement);
        snakeElement.GetComponent<SnakeElement>().health = settings.GetComponent<Settings>().firstTankHealth * Mathf.Pow(settings.GetComponent<Settings>().nextTankHealthScale, snakeElements.Count-1);
        snakeElement.GetComponent<SnakeElement>().ChooseType(typeIdx, setPosition);
    }

    public void ChooseType(int idx) {
        typeIdx = idx;
        for (int i = 0; i < settings.GetComponent<Settings>().snakeInitSize; i++) {
            AddElement();
        }
        for (int i = 0; i < settings.GetComponent<Settings>().snakeInitSize-1; i++) {
            for (int j = 0; j < settings.GetComponent<Settings>().nextTankIterationsDelay; j++) {
                foreach (GameObject el in snakeElements) {
                    el.GetComponent<SnakeElement>().move(settings.GetComponent<Settings>().startPositions[idx].x * settings.GetComponent<Settings>().startPositionScale, settings.GetComponent<Settings>().startPositions[idx].y * settings.GetComponent<Settings>().startPositionScale, 0.005f);
                }
            }
        }

    }

    void Update()
    {
        
    }
}
