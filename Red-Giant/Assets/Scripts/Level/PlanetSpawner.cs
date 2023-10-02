using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class PlanetSpawner : MonoBehaviour
{
    public Planet[] planets;
    public float[] weights;
    public float spawn_box_size = 10000f;
    public float spawn_box_dist = 20f;
    public Sun sun;
    public int initSpawnCount = 40;


    ObjectPool<Planet> pool;
    float totalWeight;
    float timer;
    float interval;
    public float spawn_rate = 1f;

    Planet spawn()
    {
        var rand = Random.Range(0, planets.Length);
        Planet new_planet = Instantiate(planets[rand]);
        new_planet.transform.position += new Vector3(Random.Range(-spawn_box_size, spawn_box_size),
                                                     Random.Range(-spawn_box_size, spawn_box_size),
                                                     Random.Range(sun.transform.localScale.x + spawn_box_dist, sun.transform.localScale.x + spawn_box_dist + spawn_box_size));
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
            planet.transform.position += new Vector3(Random.Range(-spawn_box_size, spawn_box_size),
                                             Random.Range(-spawn_box_size, spawn_box_size),
                                             Random.Range(sun.transform.localScale.x + spawn_box_dist, sun.transform.localScale.x + spawn_box_dist + spawn_box_size));
        }, planet => {
            planet.gameObject.SetActive(false);
        }, planet => {
            Destroy(planet.gameObject);
        });

        timer = Time.time;
        interval = 1f / spawn_rate;

        for (int i =0; i < initSpawnCount; i++)
        {
            pool.Get();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time - timer > interval)
        {
            Planet planet = pool.Get();
            timer = Time.time;
        }*/
    }
}
