using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab; // Ground �������� �巡�� �� ������� �Ҵ�
    public int poolSize = 10; // ������Ʈ Ǯ ũ��
    public Material grassMaterial; // Grass Material�� �巡�� �� ������� �Ҵ�
    public Material roadMaterial; // Road Material�� �巡�� �� ������� �Ҵ�
    public GameObject rightSpawnerPrefab; // Right_Spawner �������� �Ҵ�
    public GameObject leftSpawnerPrefab; // Left_Spawner �������� �Ҵ�

    List<GameObject> groundPool;
    public static bool isGroundSetupComplete = false; // GroundManager �Ϸ� ���θ� ��Ÿ���� �÷���

    void Start()
    {
        groundPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(groundPrefab);
            obj.SetActive(false);
            groundPool.Add(obj);
        }

        for (int i = 0; i < poolSize; i++)
        {
            Vector3 spawnPosition = new Vector3(i * 5, -0.5f, 0);
            groundPool[i].transform.position = spawnPosition;
            groundPool[i].SetActive(true);

            if (i == 0)
            {
                groundPool[i].GetComponent<Renderer>().material = grassMaterial; // ù ��° Ground�� Material�� Grass�� ����
            }
            else
            {
                // 50% Ȯ���� Grass �Ǵ� Road Material ����
                if (Random.Range(0, 2) == 0)
                {
                    groundPool[i].GetComponent<Renderer>().material = grassMaterial;
                    Debug.Log("Grass Material assigned to ground at position: " + groundPool[i].transform.position);
                }
                else
                {
                    groundPool[i].GetComponent<Renderer>().material = roadMaterial;
                    Debug.Log("Road Material assigned to ground at position: " + groundPool[i].transform.position);
                }

                if (groundPool[i].GetComponent<Renderer>().material == roadMaterial)
                {
                    int random = Random.Range(0, 2);
                    if (random == 0)
                    {
                        Vector3 rightSpawnerPosition = new Vector3(groundPool[i].transform.position.x, 2, -47.5f);
                        GameObject rightSpawner = Instantiate(rightSpawnerPrefab, rightSpawnerPosition, Quaternion.identity);
                        Debug.Log("Right Spawner created at position: " + rightSpawnerPosition);
                        if (rightSpawner == null)
                        {
                            Debug.LogError("Right Spawner instantiation failed.");
                        }
                    }
                    else
                    {
                        Vector3 leftSpawnerPosition = new Vector3(groundPool[i].transform.position.x, 2, 47.5f);
                        GameObject leftSpawner = Instantiate(leftSpawnerPrefab, leftSpawnerPosition, Quaternion.identity);
                        Debug.Log("Left Spawner created at position: " + leftSpawnerPosition);
                        if (leftSpawner == null)
                        {
                            Debug.LogError("Left Spawner instantiation failed.");
                        }
                    }
                }
            }
        }

        isGroundSetupComplete = true; // GroundManager �Ϸ�
    }
}
