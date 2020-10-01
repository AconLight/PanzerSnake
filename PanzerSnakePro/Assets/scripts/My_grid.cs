using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_grid : MonoBehaviour
{

    public GameObject gridElementPrefab; 
    public int sizeX;
    public int sizeY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -(sizeX-1)/2; i <= (sizeX-1)/2; i++) {
            for (int j = -(sizeY-1)/2; j <= (sizeY-1)/2; j++) {
                Instantiate(gridElementPrefab, new Vector3(i*2, j*2, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
