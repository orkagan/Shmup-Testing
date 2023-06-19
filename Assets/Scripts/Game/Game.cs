using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(ConstantAsteroids());
    }

    public GameObject SpawnAsteroid()
    {
        GameObject spaceRock = Resources.Load<GameObject>("Prefabs/Asteroid");

        GameObject asteroid = Instantiate(spaceRock);
        asteroid.transform.position = new Vector2(Random.Range(-9,9),8);
        Debug.Log("SPACE ROCK SUMMONED");
        return asteroid;
    }

    public IEnumerator ConstantAsteroids()
    {
        while (player.alive)
        {
            Destroy(SpawnAsteroid(), 5f); //spawns asteroid to be destroyed after 5 seconds
            yield return new WaitForSeconds(2);
        }
    }
}
