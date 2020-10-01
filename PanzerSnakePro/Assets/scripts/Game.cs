using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject gridPrefab; 
    public GameObject snakePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gridPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject snake1 = Instantiate(snakePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        snake1.GetComponent<Snake>().ChooseType(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
