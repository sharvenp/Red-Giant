using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlanetSpawner : MonoBehaviour
{
    public Planet[] planets;
    public float spawn_box_size = 10000f;
    public float spawn_box_dist = 20f;
    public Sun sun;


    ObjectPool<Planet> pool;

    float timer;
    float interval;
    public float spawn_rate = 1f;

    void randomizePlanet(Planet planet)
    {
        planet.transform.position += new Vector3(Random.Range(-spawn_box_size, spawn_box_size),
                                                     Random.Range(-spawn_box_size, spawn_box_size),
                                                     Random.Range(sun.transform.localScale.x + spawn_box_dist, sun.transform.localScale.x + spawn_box_dist + spawn_box_size));
        planet.transform.rotation = Random.rotation;
    }

    Planet spawn()
    {
        var rand = Random.Range(0, planets.Length);
        Planet new_planet = Instantiate(planets[rand]);
        randomizePlanet(new_planet);
        new_planet.pool = pool;
        return new_planet;
    }
    void Start()
    {
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

        timer = Time.time;
        interval = 1f / spawn_rate;

        for (int i =0; i < 40; i++)
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
