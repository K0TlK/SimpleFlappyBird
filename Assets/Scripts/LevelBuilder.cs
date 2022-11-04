using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelBuilder : Singleton<LevelBuilder>
{
    [SerializeField] private Obstruction Base;
    [SerializeField] private Obstruction[] obstructions;
    [SerializeField] private int activeObstructionsCount = 4;
    [SerializeField] private Transform levelObjects;
    private List<Obstruction> obstructionQueue = new List<Obstruction>();

    public void StartGame()
    {
        ClearLevel();
        Obstruction tmp = Instantiate(Base, levelObjects);
        obstructionQueue.Add(tmp);
        tmp.transform.position = -tmp.ExitPoint * 2;
        AddObstruction(Base);

        for (int i = 2; i < activeObstructionsCount; i++)
        {
            AddObstruction();
        }
    }

    private void ClearLevel()
    {
        foreach (Transform child in levelObjects)
        {
            GameObject.Destroy(child.gameObject);
        }
        obstructionQueue.Clear();
    }

    public void NextStep()
    {
        Destroy(obstructionQueue[0].gameObject);
        obstructionQueue.RemoveAt(0);
        AddObstruction();
    }

    private void AddObstruction()
    {
        AddObstruction(obstructions[Random.Range(0, obstructions.Length)]);
    }

    private void AddObstruction(Obstruction obstruction)
    {
        Vector3 prevExitPoint = obstructionQueue[obstructionQueue.Count - 1].ExitPointGlobal;
        Obstruction tmp = Instantiate(obstruction, levelObjects);
        tmp.transform.position = prevExitPoint - tmp.EnterPoint;
        tmp.Init();
        obstructionQueue.Add(tmp);
    }
}
