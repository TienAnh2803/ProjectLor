using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 0f;
    private float verticalInput;
    private float horizontalInput;
    private GameObject cameRa;
    private GameObject gun;
    private GameObject gun2;
    public GameObject bulletPre;
    private GameObject bulletPos;
    private GameObject bulletPos2;
    private float spin = 1000;
    private float fireRate = 0.1f;
    private float nextFireTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cameRa = GameObject.Find("MainCamera");
        bulletPos = GameObject.Find("SpawnPos");
        bulletPos2 = GameObject.Find("SpawnPos2");
        gun = GameObject.Find("Gun");
        gun2 = GameObject.Find("Gun2");

    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(Vector3.left, Time.deltaTime * turnSpeed * verticalInput);
        transform.Rotate(cameRa.transform.forward, Time.deltaTime * turnSpeed * horizontalInput);
        if (Input.GetKey(KeyCode.Space))
        {
            gun.transform.Rotate(Vector3.up * spin);
            gun2.transform.Rotate(Vector3.up * spin);
        }
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPre, bulletPos.transform.position, bulletPos.transform.rotation);
            bulletPos.transform.rotation = transform.rotation;
            Instantiate(bulletPre, bulletPos2.transform.position, bulletPos2.transform.rotation);
            bulletPos2.transform.rotation = transform.rotation;
        }
    }
}
