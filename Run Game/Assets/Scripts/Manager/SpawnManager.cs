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
    [SerializeField] int count;
    void Start()
    {
        
        vehicleList.Capacity = 20;
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
            random = Random.Range(0, vehicleObject.Length);

            while (vehicleList[random].activeSelf == true)
            {
               
                count++;
                if(count >=vehicleObject.Length)
                {
                    yield break;
                }

                random = (random + 1) % vehicleObject.Length;
            }

            vehicleList[random].SetActive(true);
            
            yield return new WaitForSeconds(5);

        }

    }
   
    
}
