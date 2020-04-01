using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 2;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {
        
    }
}
