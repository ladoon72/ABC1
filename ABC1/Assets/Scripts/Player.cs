using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
