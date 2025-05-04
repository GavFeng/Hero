using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float rotationSpeed = 180f; 
    private Camera mainCamera;
    public GameObject projectilePrefab;
    public float fireRate = 0.2f;        

    private float nextFireTime = 0f;

    public float moveSpeed = 1f;
    private float currentSpeed;
    public float speedModifier = 2f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.Instance.SwitchHeroMode();
        }

        if (GameManager.Instance.isHeroModeMouse)
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
        else
        {
            float input = Input.GetAxisRaw("Vertical");

            if (input > 0)
            {
                if (currentSpeed < 0)
                {
                    currentSpeed = Mathf.Min(0, currentSpeed + speedModifier * Time.deltaTime);
                }
                else {
                    currentSpeed = Mathf.Max(moveSpeed, currentSpeed + speedModifier * Time.deltaTime);

                }
            }
            else if (input < 0)
            {
                if (currentSpeed > 0) {
                    currentSpeed = Mathf.Max(0, currentSpeed - speedModifier * Time.deltaTime);
                }
                else
                {
                    currentSpeed = Mathf.Min(-moveSpeed, currentSpeed - speedModifier * Time.deltaTime);
                }
            }
            transform.position += transform.up * currentSpeed * Time.deltaTime;
        }


        float rotationInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -rotationInput * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime) {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            GameManager.Instance.IncreaseEggCount();
            nextFireTime = Time.time + fireRate;
        }
    }




}
