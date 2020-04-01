using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public float awakeTimer = 25f;
    [SerializeField]
    private float currentAwakeTime = 0;

    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            StartCoroutine("Wake");
            Destroy(other.gameObject);
        }
    }

    IEnumerator Wake()
    {
        light.enabled = true;
        yield return new WaitForSeconds(awakeTimer);
        light.enabled = false;
    }
}
