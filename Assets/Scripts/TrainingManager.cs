using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private int envAmount = 10;
    [SerializeField] private float spacing = 5f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < envAmount; i++)
        {
            Instantiate(prefabToSpawn, new Vector3(2.43286f, 0.2204369f, spacing * i), Quaternion.identity);
        }
    }
}
