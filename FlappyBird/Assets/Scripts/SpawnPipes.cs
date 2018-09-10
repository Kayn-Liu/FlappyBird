using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************************************************************************
Mount: PipeSpawnRoot
Function: To Spawn the root from the parent location
**************************************************************************/
public class SpawnPipes : MonoBehaviour
{
    //--------------------------------------------------
    //Variables Definition
    GameObject Pipes;
    Transform parent;
    const float spawnTime = 1.0f;
    const float spawnRate= 1.1f;
    const float pipeTop = 135f;
    const float pipeBtm = -55f;

    //--------------------------------------------------
    //Unity Cycle
    private void Awake()
    {
        Pipes = Resources.Load<GameObject>(@"Prefabs\Pipes");
        parent = GameObject.Find("PipeSpawnRoot").transform;
    }
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("GetPipes", spawnTime, spawnRate);
    }

    //--------------------------------------------------
    //Functions Definition
    void GetPipes()
    {
        float y = Random.Range(pipeBtm, pipeTop);
        Pipes = Instantiate(Pipes,parent);
        Pipes.name = "Pipes";
        RectTransform rect = Pipes.GetComponent<RectTransform>();
        rect.anchoredPosition3D = new Vector3(0.0f, y, 0.0f);
        rect.localScale = Vector3.one;
    }

}
