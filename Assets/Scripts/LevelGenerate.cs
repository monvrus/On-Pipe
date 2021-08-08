using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    private GameObject cylinder;

    [SerializeField]
    private Color enemy_cylinder;
   
    private GameObject previous_cylinder;

    [SerializeField]
    private float minRadius, maxRadius;

    #endregion



    #region Fucntions

    private float FindRadius(float minR, float maxR) 
    {
        float radius = Random.Range(minR, maxR);

        if(previous_cylinder != null)
        {
            while (Mathf.Abs(radius - previous_cylinder.transform.localScale.x) < 0.4f)
            {
                radius = Random.Range(minR, maxR);
            }
        }

     
        return radius;
    }

    public void SpawnCylinder()
    {
        float radius = FindRadius(minRadius, maxRadius);
        float height = Random.Range(2f, 6f);


        cylinder.transform.localScale = new Vector3(radius, height, radius);

        if (previous_cylinder == null) 
        {
            previous_cylinder = Instantiate(cylinder, Vector3.zero, Quaternion.identity);

        }
        else
        {

            float spawnPoint = previous_cylinder.transform.position.z + previous_cylinder.transform.localScale.y + cylinder.transform.localScale.y;
            previous_cylinder = Instantiate(cylinder, new Vector3(0, 0, spawnPoint), Quaternion.identity);

            if (Random.value < 0.1f)
            {
                previous_cylinder.GetComponent<Renderer>().material.color = enemy_cylinder;
                previous_cylinder.tag = "Enemy";
            }


        }
        previous_cylinder.transform.Rotate(90, 0, 0);
    }
    #endregion


}
