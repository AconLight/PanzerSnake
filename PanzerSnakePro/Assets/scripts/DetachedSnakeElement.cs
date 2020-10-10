using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedSnakeElement : MonoBehaviour
{
    private int typeIdx;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChooseType(int idx, GameObject tankPrefab, GameObject weaponPrefab) {
        typeIdx = idx;
        Instantiate(tankPrefab, gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
        Instantiate(weaponPrefab, gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
