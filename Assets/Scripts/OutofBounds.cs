using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    public float minX = -10f; 
    public float maxX = 10f;  
    public float minY = -10f; 
    public float maxY = 10f;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY)
        {
            Destroy(gameObject);
        }
    }
}
