using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Transform[] transEnemies;
    [SerializeField] private GameObject enemy;
    [SerializeField]  private int round = 1;

    public Transform player;

    private int actualRound = 0;
    private GameObject refEnemy;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actualRound != round)
        {

            foreach (Transform transEnemy in transEnemies)
            {

                int canthijos = transEnemy.childCount;

                
                for (int i = 0; i < canthijos; i++)
                {

                    GameObject obj = transEnemy.GetChild(i).gameObject;

                    Destroy(obj);

                }

                int cantRandom = Random.Range(0, 5);

                for (int i = 0; i < cantRandom; i++)
                {

                    float x = Random.Range(0.5f, 3f);
                    float y = Random.Range(0.5f, 3f);

                    Vector3 posicion = new Vector3(x, y);

                    refEnemy = Instantiate(enemy, transEnemy);
                    refEnemy.GetComponent<AIDestinationSetter>().target = player;

                    refEnemy.GetComponent<Transform>().position += posicion;

                }


            }

        }
    }

    private void LateUpdate()
    {
        actualRound = round;
    }
}
