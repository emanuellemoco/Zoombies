using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject holdpoint;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.SetParent(Camera.main.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
