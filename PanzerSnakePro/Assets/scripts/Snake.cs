using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

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
        } else {
            snakeElement = Instantiate(snakeElementPrefab, startPosition, Quaternion.identity, gameObject.transform);
        }
        snakeElements.Add(snakeElement);
        snakeElement.GetComponent<SnakeElement>().ChooseType(typeIdx);
    }

    public void ChooseType(int idx) {
        typeIdx = idx;
        AddElement();
        AddElement();
        AddElement();
    }

    void Update()
    {
        
    }
}
