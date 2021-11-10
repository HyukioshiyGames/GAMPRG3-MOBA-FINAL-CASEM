using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectObserver : MonoBehaviour
{
    public static ObjectObserver instance;

    public List<GameObject> creeps;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
    }

    public void AddCreepToList(GameObject _toAdd)
    {
        if (!creeps.Contains(_toAdd))
            creeps.Add(_toAdd);
    }
    public void RemoveCreepToList(GameObject _toRemove)
    {
        if (creeps.Contains(_toRemove))
            creeps.Remove(_toRemove);
    }

    public void StopAllCreeps() 
    {
        for (int i = 0; i < creeps.Count; i++)
        {
            creeps[i].GetComponent<Creep>().creepAnimator.UnplayBasicAttack();
            creeps[i].GetComponent<Creep>().ChangeState(Creep.States.Idle);
            creeps[i].GetComponent<Creep>().agent.velocity = Vector3.zero;
            creeps[i].GetComponent<Creep>().agent.isStopped = true;

            creeps[i].GetComponent<Creep>().enabled = false;

        }
    }
}
