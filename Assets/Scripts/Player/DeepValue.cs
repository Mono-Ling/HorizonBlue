using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepValue : MonoBehaviour
{
    public Transform hight;
    public Transform low;
    private const int _maxDeep = 200;
    // Start is called before the first frame update
    void Start()
    {
        if(!hight || !low)
            Debug.LogError("【空引用】");
    }

    // Update is called once per frame
    void Update()
    {
        float num = 1 - (transform.position.y  - low.position.y) / (hight.position.y - low.position.y);
        int currDeep = (int)(_maxDeep * num);
        GlobalValue.Instance.SetCurrentDeep(currDeep);
    }
}
