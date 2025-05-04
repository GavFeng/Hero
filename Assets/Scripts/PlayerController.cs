using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float rotationSpeed = 180f; 
    private Camera mainCamera;
    public GameObject projectilePrefab;
    public float fireRate = 0.2f;        

    private float nextFireTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        float rotationInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -rotationInput * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime) {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }




}
