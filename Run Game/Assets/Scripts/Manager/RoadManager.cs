using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    
    [SerializeField] float offset = 25.0f;
    [SerializeField] List<GameObject> roadList;

    private void Start()
    {
        roadList.Capacity = 10;
    }

    private void Update()
    {
        if (GameManager.instance.state == false) return;
        for(int i=0; i<roadList.Count; i++)
        {
            roadList[i].transform.Translate(Vector3.back * GameManager.instance.Speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = roadList[0];

        roadList.Remove(newRoad);

        float newZ = roadList[roadList.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);

        roadList.Add(newRoad);
        
    }

}
