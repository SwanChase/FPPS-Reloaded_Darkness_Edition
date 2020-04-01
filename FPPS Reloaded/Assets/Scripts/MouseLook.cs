using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSpeed = 100;

    public Transform playerbody;
    private float xRot = 0f;

    [SerializeField]
    private float offset, bulletSpeed1, bulletSpeed2, bulletSpeedMultiplier = 1000;
    [SerializeField]
    private GameObject barrelEnd;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject secProjectile;

    private Vector3 endGun;
    private Quaternion rotationOfGunEnd;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerbody.Rotate(Vector3.up * mouseX);

        endGun = barrelEnd.transform.position;
        rotationOfGunEnd = barrelEnd.transform.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile(projectile, bulletSpeed1, bulletSpeedMultiplier);
        }
        if (Input.GetMouseButtonDown(1))
        {
            FireProjectile(secProjectile, bulletSpeed2, bulletSpeedMultiplier);
        }
    }

    void FireProjectile(GameObject _bullet, float _bulletSpeed, float _bulletSpeedMultiplier)
    {
        var newObject = Instantiate(_bullet, barrelEnd.transform.position + (barrelEnd.transform.up * offset), barrelEnd.transform.rotation);
        newObject.GetComponent<Rigidbody>().AddForce(newObject.transform.up * _bulletSpeed * _bulletSpeedMultiplier);
    }

}

