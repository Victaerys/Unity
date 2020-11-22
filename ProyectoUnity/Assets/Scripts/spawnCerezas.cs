using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class spawnCerezas : MonoBehaviour
{

    [SerializeField] private List<GameObject> listaCerezas;

    public Vector3 centro;
    public Vector3 dimensiones;

    private bool libre = true;


    // Start is called before the first frame update
    void Start()
    {
        listaCerezas.Add(GameObject.Find("CerezaRoja"));
        listaCerezas.Add(GameObject.Find("CerezaAzul"));
        listaCerezas.Add(GameObject.Find("CerezaAmarilla"));
  
    }

    // Update is called once per frame
    async void Update()
    {
        if (libre)
        {
            libre = false;
            await Task.Delay(Random.Range(2000, 5000));
            spawn();
            libre = true;
        }
        
    }

    public void spawn()
    {
        Vector3 pos = transform.localPosition + centro + new Vector3(Random.Range(-dimensiones.x / 2, dimensiones.x / 2), Random.Range(-dimensiones.y / 2, dimensiones.y / 2), 1);
        Instantiate(listaCerezas[Random.Range(0, listaCerezas.Count)], pos, Quaternion.identity, transform);
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.localPosition + centro, dimensiones);
    }

}
