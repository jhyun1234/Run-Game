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

                // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                while (vehicleList[random].activeSelf == true)
                {
                    if (FullVehicle()) // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                    {
                        // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                        // vehicle을 리스트에 넣어줍니다.
                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);

                        vehicle.SetActive(false);

                        vehicleList.Add(vehicle);
                    }

                    // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있지 않다면
                    // random 변수의 값을 +1을 해서 다시 검색합니다.
                    random = (random + 1) % vehicleList.Count;
                }

                // 랜덤으로 위치를 설정하는 변수를 선언합니다.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // 만약에 내가 이전에 저장되어 있던 변수와 다시 뽑은 randomPosition의 값이
                // compare 변수와 일치하다면 중복이 되지 않도록 계산합니다.
                if (compare == randomPosition)
                {
                    randomPosition = (randomPosition + 1) % spawnPosition.Length;
                }

                // compare 변수와 random으로 설정된 변수의 값을 넣어줍니다.
                compare = randomPosition;

                // vehicle 오브젝트가 할성화되는 위치를 랜덤으로 설정합니다.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // 랜덤으로 설정된 vehicle 오브젝트를 활성화합니다.
                vehicleList[random].SetActive(true);
            }

            yield return CoroutineCache.WaitForSeconds(LevelManager.spawnTime);
        }


    }

}
