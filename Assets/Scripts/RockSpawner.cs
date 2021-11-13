using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns Rocks Periodically & with given condition
/// </summary>
public class RockSpawner : MonoBehaviour
{
    // get the prefabs
    [SerializeField]
    GameObject greenRock;
    [SerializeField]
    GameObject magentaRock;
    [SerializeField]
    GameObject whiteRock;

    // set parameters to control spawning
    float spawnDelay=1;
    Timer spawnTimer;
    int numberOfRocks = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = GetComponent<Timer>();
        spawnTimer.Duration = spawnDelay;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer.Finished)
        {
            numberOfRocks = GameObject.FindGameObjectsWithTag("rockInGame").Length;
            if (numberOfRocks < 3)
            {
                SpawnerMethod();
                spawnTimer.Run();
            }
        }
    }

    void SpawnerMethod()
    {
        Vector3 location = new Vector3(Screen.width / 2, Screen.height / 2, -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        int prefabNumber = Random.Range(0, 3);
        if (prefabNumber == 0)
        {
            GameObject rock = Instantiate<GameObject>(greenRock,worldLocation,Quaternion.identity);
            rock.tag = "rockInGame";
        }
        else if (prefabNumber == 1)
        {
            GameObject rock = Instantiate<GameObject>(magentaRock,worldLocation,Quaternion.identity);
            rock.tag = "rockInGame";
        }
        else
        {
            GameObject rock = Instantiate<GameObject>(whiteRock,worldLocation,Quaternion.identity);
            rock.tag = "rockInGame";
        }
    }
}
