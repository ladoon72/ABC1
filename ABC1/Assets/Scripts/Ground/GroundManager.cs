using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab; // Ground 프리팹을 드래그 앤 드롭으로 할당
    public int poolSize = 10; // 오브젝트 풀 크기
    public Material grassMaterial; // Grass Material을 드래그 앤 드롭으로 할당
    public Material roadMaterial; // Road Material을 드래그 앤 드롭으로 할당
    public GameObject rightSpawnerPrefab; // Right_Spawner 프리팹을 할당
    public GameObject leftSpawnerPrefab; // Left_Spawner 프리팹을 할당

    List<GameObject> groundPool;
    public static bool isGroundSetupComplete = false; // GroundManager 완료 여부를 나타내는 플래그

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
                groundPool[i].GetComponent<Renderer>().material = grassMaterial; // 첫 번째 Ground의 Material을 Grass로 설정
            }
            else
            {
                // 50% 확률로 Grass 또는 Road Material 설정
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

        isGroundSetupComplete = true; // GroundManager 완료
    }
}
