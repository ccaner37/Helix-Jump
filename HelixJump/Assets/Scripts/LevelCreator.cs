using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Transform prefab;
    Material material;
    public int levelLength;

    void Start()
    {
        CreateLevel();
    }

   void CreateLevel()
    {
        for (int i = 0; i < levelLength; i++)
        {

            if (i == levelLength - 1)
            {
                var platform = Instantiate(prefab, new Vector3(-6.60f, i * -5, -9.44f), Quaternion.identity, transform);
                Material newMat = Resources.Load("GOAL_Green", typeof(Material)) as Material;

                for (int child = 0; child < platform.GetChildCount(); child++)
                {
                    var goalPlatformChild = platform.GetChild(child);
                    goalPlatformChild.GetComponent<Renderer>().material = newMat;
                    goalPlatformChild.gameObject.tag = "Goal";
                }

            }
            else
            {
                var platform = Instantiate(prefab, new Vector3(-6.60f, i * -5, -9.44f), Quaternion.identity, transform);

                int randomPlatformNumberForMaterial = Random.Range(0, 12);
                int randomPlatformNumberForRemove = Random.Range(0, 12);

                int randomPlatformNumberForMaterial2 = Random.Range(0, 12);
                int randomPlatformNumberForRemove2 = Random.Range(0, 12);

                if (randomPlatformNumberForRemove == randomPlatformNumberForMaterial) { randomPlatformNumberForRemove += Random.Range(1, 3); }
                if (randomPlatformNumberForRemove >= 12) { randomPlatformNumberForRemove = 1; }

                var randomPlatform = platform.GetChild(randomPlatformNumberForMaterial);
                var randomPlatformRemove = platform.GetChild(randomPlatformNumberForRemove);

                var randomPlatform2 = platform.GetChild(randomPlatformNumberForMaterial2);
                var randomPlatformRemove2 = platform.GetChild(randomPlatformNumberForRemove2);

                Destroy(randomPlatformRemove.gameObject);
                Destroy(randomPlatformRemove2.gameObject);

                Material newMat = Resources.Load("DEATH_Red", typeof(Material)) as Material;
                randomPlatform.GetComponent<Renderer>().material = newMat;
                randomPlatform.gameObject.tag = "Death";
                randomPlatform2.GetComponent<Renderer>().material = newMat;
                randomPlatform2.gameObject.tag = "Death";
            }


           
        }
        
    }
}
