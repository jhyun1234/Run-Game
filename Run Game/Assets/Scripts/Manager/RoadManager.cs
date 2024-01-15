using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] List<GameObject> roadList;

    private void Start()
    {
        roadList.Capacity = 10;
    }

    private void Update()
    {
        for(int i=0; i<roadList.Count; i++)
        {
            roadList[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = new GameObject();
        
    }

}
