using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public GameObject Water;

    public GameObject Goal;

    public GameObject Post;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
        parentTransform.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
    }

    
    private void FileParser()
    {
        
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int column = 0;
            int colPos = 0;
            

            while ((line = sr.ReadLine()) != null)
            {
                int row = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    
                    // Call SpawnPrefab
                    if (letter != ' ')
                    {
                        SpawnPrefab(letter, new Vector3(row, colPos, -.5f));
                    }
                    ++row;      
                }
                column = column + 1;
                //negate 
                colPos = column * -1;
            }
            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': ToSpawn = Brick;       break;
            case '?': ToSpawn = QuestionBox;       break;
            case 'x': ToSpawn = Rock;       break;
            case 's': ToSpawn = Stone;       break;
            case 'w': ToSpawn = Water; break;
            case 'g': ToSpawn = Goal; break;
            case 'p': ToSpawn = Post; break;

            //default: Debug.Log("Default Entered"); break;
            default: return;
            //ToSpawn = //Brick;       break;
        }

        //Debug.Log("Spawning " + spot + " (" + positionToSpawn + ")");
        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
