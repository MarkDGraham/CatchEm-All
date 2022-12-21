using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                              EntityManager.cs
 *                                Mark Graham      
 *                              December 11, 2022
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 *  Modification Log:
 *      2022:
 *          December:
 *              12: Comments added.
 *              11: Implemented spawn location randomization.
 *              11: Implemented game object pools collections.
 *              11: Singleton implemented.
 *              11: Script created. 
 */

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;

    void Awake()
    {
        if (instance != null)
            Destroy(this);

        if (instance == null)
            instance = this;
    }

    // Variables:
    private float _upperBound = 8.0f, _lowerBound = -8.0f, _yHeight = 11.0f;
    private List<int> _spawnRates = new List<int> { 0, 0, 0, 0, 0, 1, 2, 3, 4 };
    [SerializeField] List<GameObject> _basicBallPool = new List<GameObject>();
    [SerializeField] List<GameObject> _scoreUpPool = new List<GameObject>();
    [SerializeField] List<GameObject> _scoreDownPool = new List<GameObject>();
    [SerializeField] List<GameObject> _timeUpPool = new List<GameObject>();
    [SerializeField] List<GameObject> _timeDownPool = new List<GameObject>();

    // Out of frame spawn location randomizer.
    public Vector3 GetSpawnLocation()
    {
        return new Vector3(Random.Range(_lowerBound, _upperBound), _yHeight, 0);
    }

    // Enables ball base on spawn genration pobability.
    public void SpawnObject()
    {
        switch (_spawnRates[Random.Range(0, _spawnRates.Count)])
        {
            case 0: ActivateObject(_basicBallPool);
                break;
            case 1: ActivateObject(_scoreUpPool);
                break;
            case 2: ActivateObject(_scoreDownPool);
                break;
            case 3: ActivateObject(_timeUpPool);
                break;
            case 4: ActivateObject(_timeDownPool);
                break;
        }
    }


    // Enables next available game object and sets spawn location.
    private void ActivateObject(List<GameObject> objectList)
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            if (objectList[i].activeInHierarchy == false)
            {
                objectList[i].transform.position = GetSpawnLocation();
                objectList[i].SetActive(true);
                break;
            }
        }
    }

    // Disables game object passed in and sets velocity to zero.
    public void DeactivateObject(GameObject deactivatable)
    {
        deactivatable.GetComponent<Rigidbody>().velocity = Vector3.zero;
        deactivatable.SetActive(false);
    }
}
