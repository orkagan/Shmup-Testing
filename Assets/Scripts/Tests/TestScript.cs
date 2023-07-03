using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private Game game;
    [SetUp]
    public void SetUp()
    {
        GameObject testGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = testGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator PlayerMovesRight()
    {
        Player player = game.player;

        Vector2 playerPosition = player.gameObject.transform.position;
        player.Move(new Vector2(1, 0));
        yield return null;
        Assert.Greater(player.gameObject.transform.position.x,playerPosition.x);
    }
    
    [UnityTest]
    public IEnumerator AsteroidFalling()
    {
        GameObject asteroid = game.SpawnAsteroid();

        Vector2 asteroidPosition = asteroid.transform.position;
        yield return new WaitForSeconds(2f);
        Assert.Less(asteroid.transform.position.y,asteroidPosition.y);

        yield return null;
    }

    [UnityTest]
    public IEnumerator LaserDestroyAsteroid()
    {
        GameObject asteroid = game.SpawnAsteroid();
        GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Laser"));

        bullet.transform.position = asteroid.transform.position;

        yield return new WaitForSeconds(0.1f);
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }
}
