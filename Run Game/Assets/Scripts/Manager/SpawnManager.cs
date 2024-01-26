using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;
    [SerializeField] GameObject[] vehicleObject;

    [SerializeField] List<GameObject> vehicleList;

    [SerializeField] int random;
    [SerializeField] int compare = -1;
    [SerializeField] int randomPosition;

    void Start()
    {
        vehicleList.Capacity = 20;

        Create();

        StartCoroutine(ActiveVehicle());
    }

    public void Create()
    {
        for (int i = 0; i < vehicleObject.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObject[i]);

            vehicle.SetActive(false);

            vehicleList.Add(vehicle);
        }
    }

    public bool FullVehicle()
    {
        for (int i = 0; i < vehicleList.Count; i++)
        {
            if (vehicleList[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator ActiveVehicle()
    {
        while (GameManager.instance.state)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

                // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                while (vehicleList[random].activeSelf == true)
                {
                    if (FullVehicle()) // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                    {
                        // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                        // vehicle�� ����Ʈ�� �־��ݴϴ�.
                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);

                        vehicle.SetActive(false);

                        vehicleList.Add(vehicle);
                    }

                    // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ���� �ʴٸ�
                    // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                    random = (random + 1) % vehicleList.Count;
                }

                // �������� ��ġ�� �����ϴ� ������ �����մϴ�.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // ���࿡ ���� ������ ����Ǿ� �ִ� ������ �ٽ� ���� randomPosition�� ����
                // compare ������ ��ġ�ϴٸ� �ߺ��� ���� �ʵ��� ����մϴ�.
                if (compare == randomPosition)
                {
                    randomPosition = (randomPosition + 1) % spawnPosition.Length;
                }

                // compare ������ random���� ������ ������ ���� �־��ݴϴ�.
                compare = randomPosition;

                // vehicle ������Ʈ�� �Ҽ�ȭ�Ǵ� ��ġ�� �������� �����մϴ�.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // �������� ������ vehicle ������Ʈ�� Ȱ��ȭ�մϴ�.
                vehicleList[random].SetActive(true);
            }

            yield return CoroutineCache.WaitForSeconds(LevelManager.spawnTime);
        }


    }

}
