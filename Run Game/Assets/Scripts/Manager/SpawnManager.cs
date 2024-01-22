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

    public bool FullVehicle()
    {
        for(int i=0; i<vehicleList.Count;i++)
        {
            if (vehicleList[i].activeSelf ==false)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator ActiveVehicle()
    {

        while (true)
        {
            for (int i = 0; i < Random.Range(1,3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

                // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ��� Ȯ���Ѵ�.
                while (vehicleList[random].activeSelf == true)
                {

                    if(FullVehicle()) // ���� ����Ʈ�� �ִ� ��� ���� ���ꤸ
                    {
                        // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                        // vehicle �� ����Ʈ�� �־��ش�.

                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);
                        vehicle.SetActive(false);

                        vehicleList.Add(vehicle);
                    }

                    // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ���� �ʴٸ�
                    // random ������ ���� +1�� �ؼ� �ٽ� �˻��Ѵ�.

                    random = (random + 1) % vehicleList.Count;
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
            yield return CoroutineCache.WaitForSeconds(5f);

        }

    }
   
    
}
