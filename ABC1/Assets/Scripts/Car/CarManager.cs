using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarManager : MonoBehaviour
{
    public GameObject carPrefab;
    public int poolSize = 10;
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;

    List<GameObject> rightSpawnerCars;
    List<GameObject> leftSpawnerCars;
    Material[] materials;

    void Start()
    {
        rightSpawnerCars = new List<GameObject>();
        leftSpawnerCars = new List<GameObject>();

        materials = new Material[] { redMaterial, greenMaterial, blueMaterial };

        StartCoroutine(WaitForGroundSetup());
    }

    IEnumerator WaitForGroundSetup()
    {
        // GroundManager가 완료될 때까지 대기
        while (!GroundManager.isGroundSetupComplete)
        {
            yield return null;
        }

        // GroundManager 완료 후 실행
        GameObject[] rightSpawners = GameObject.FindGameObjectsWithTag("Right_Spawner");
        GameObject[] leftSpawners = GameObject.FindGameObjectsWithTag("Left_Spawner");

        foreach (GameObject spawner in rightSpawners)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject car = Instantiate(carPrefab);
                car.SetActive(false);
                car.transform.SetParent(spawner.transform);
                rightSpawnerCars.Add(car);
            }
        }

        foreach (GameObject spawner in leftSpawners)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject car = Instantiate(carPrefab);
                car.SetActive(false);
                car.transform.SetParent(spawner.transform);
                leftSpawnerCars.Add(car);
            }
        }

        StartCoroutine(ActivateCars());
    }

    IEnumerator ActivateCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            foreach (GameObject car in rightSpawnerCars)
            {
                if (!car.activeInHierarchy)
                {
                    ActivateCar(car);
                    break;
                }
            }

            foreach (GameObject car in leftSpawnerCars)
            {
                if (!car.activeInHierarchy)
                {
                    ActivateCar(car);
                    break;
                }
            }
        }
    }

    void ActivateCar(GameObject car)
    {
        car.SetActive(true);
        SetRandomMaterial(car);
        StartCoroutine(DeactivateCar(car, 10f));
    }

    void SetRandomMaterial(GameObject car)
    {
        Material randomMaterial = materials[Random.Range(0, materials.Length)];
        car.GetComponent<Renderer>().material = randomMaterial;
    }

    IEnumerator DeactivateCar(GameObject car, float delay)
    {
        yield return new WaitForSeconds(delay);
        car.SetActive(false);
    }
}
