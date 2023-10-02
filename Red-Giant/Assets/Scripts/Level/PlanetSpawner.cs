using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class PlanetSpawner : MonoBehaviour
{
    public Planet[] planets;
    public float[] weights;
    public float spawn_box_size = 10000f;
    public float spawn_max_dist = 10;
    public float spawn_box_dist = 20f;
    public Sun sun;
    public int initSpawnCount = 40;


    ObjectPool<Planet> pool;
    float totalWeight;

    void randomizePlanet(Planet planet)
    {
        planet.transform.position = new Vector3(Random.Range(-spawn_box_size, spawn_box_size),
                                                     Random.Range(-spawn_box_size, spawn_box_size),
                                                     Random.Range(sun.transform.localScale.x + spawn_box_dist, sun.transform.localScale.x + spawn_box_dist + spawn_max_dist));
        planet.transform.rotation = Random.rotation;
    }

    Planet spawn()
    {
        int selectedIdx = 0;
        float spawnRandomWeight = Random.Range(0, totalWeight);

        for (int i = 0; i < planets.Length; i++)
        {
            if (spawnRandomWeight <= weights[i])
            {
                selectedIdx = i;
                break;
            }
            spawnRandomWeight -= weights[i];
        }

        Planet new_planet = Instantiate(planets[selectedIdx]);
        randomizePlanet(new_planet);
        new_planet.pool = pool;
        return new_planet;
    }
    void Start()
    {
        totalWeight = weights.Sum();

        pool = new ObjectPool<Planet>(() => {
            return spawn();
        }, planet => {
            planet.gameObject.SetActive(true);
            randomizePlanet(planet);
        }, planet => {
            planet.gameObject.SetActive(false);
        }, planet => {
            Destroy(planet.gameObject);
        });

        for (int i =0; i < initSpawnCount; i++)
        {
            pool.Get();
        }
    }
}
