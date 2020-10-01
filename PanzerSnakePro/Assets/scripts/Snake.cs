using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public GameObject snakeElementPrefab;
    // Start is called before the first frame update

    private List<GameObject> snakeElements = new List<GameObject>();

    void Start()
    {

    }

    public void ChooseType(int idx) {
        snakeElements.Add(Instantiate(snakeElementPrefab, new Vector3(0, 0, 0), Quaternion.identity));
        foreach (GameObject snakeElement in snakeElements)
        {
            snakeElement.GetComponent<SnakeElement>().ChooseType(idx);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
