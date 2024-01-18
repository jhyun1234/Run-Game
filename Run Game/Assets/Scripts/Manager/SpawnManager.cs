using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> vehicleList;
    [SerializeField] Transform[] SpawnPosition;
    [SerializeField] GameObject[] vehicleObject;
    [SerializeField] int random;
    [SerializeField] int randomPosition;
    [SerializeField] int compare = -1;
    
    void Start()
    {
        
        vehicleList.Capacity = 20;

        Create();

        StartCoroutine(ActiveVehicle());
    }

    public void Create()
    {
        for(int i=0; i<vehicleObject.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObject[i]);

            vehicle.SetActive(false);
            vehicleList.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {

        while (true)
        {
            for (int i = 0; i < Random.Range(1,3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

                while (vehicleList[random].activeSelf == true)
                {

                    

                    random = (random + 1) % vehicleObject.Length;
                }

                // �������� ��ġ�� �����ϴ� ������ �����Ѵ�.
                randomPosition = Random.Range(0, SpawnPosition.Length);

                // ���࿡ ���� ������ ����Ǿ� �ִ� ������ �ٽ� ���� randomPosition�� ����
                // compare ������ ��ġ�ϴٸ� �ߺ��� ���� �ʵ��� ����Ѵ�.
                if(compare==randomPosition)
                {
                    randomPosition = (randomPosition + 1) & SpawnPosition.Length;
                }

                // compare ������ random���� ������ ������ ���� �־��ش�.
                compare = randomPosition;

                // vehicle ������Ʈ�� Ȱ��ȭ�Ǵ� ��ġ�� �������� �����Ѵ�.
                vehicleList[random].transform.position = SpawnPosition[randomPosition].position;
                

                // �������� ������ vehicle ������Ʈ�� Ȱ��ȭ �Ѵ�.
                vehicleList[random].SetActive(true);

                
            }
            yield return new WaitForSeconds(5);

        }

    }
   
    
}
