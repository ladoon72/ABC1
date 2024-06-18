using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 5f;
    public bool isRightSpawner;

    void Start()
    {
        if (transform.parent.CompareTag("Right_Spawner"))
        {
            isRightSpawner = true;
        }
        else if (transform.parent.CompareTag("Left_Spawner"))
        {
            isRightSpawner = false;
        }
    }

    void Update()
    {
        if (isRightSpawner)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}

