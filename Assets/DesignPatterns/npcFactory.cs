using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcFactory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum NPCTypes
{
    resident=0,
    excorcist,
    pet
};

public class NPCFactory
{
    public NPC GetNPC(NPCTypes npcTypes)
    {
        switch (npcTypes)
        {
            case NPCTypes.resident:
                return new ResidentNPC();
            case NPCTypes.excorcist:
                return new ExcorcistNPC();
            case NPCTypes.pet:
                return new PetNPC();
            default:
                return new ResidentNPC();

        }
    }

}

public interface NPC
{
    void movement();
    void reactToGhost();
    void reactToInteractable();
    void getFeared();

}

public class ResidentNPC : NPC
{
   public void movement() {

    }
   public void reactToGhost()
    {

    }
    public void reactToInteractable() {

    }
    public void getFeared() {

    }
}

public class ExcorcistNPC : NPC
{
    public void movement()
    {

    }
    public void reactToGhost()
    {

    }
    public void reactToInteractable()
    {

    }
    public void getFeared()
    {

    }
}

public class PetNPC : NPC
{
    public void movement()
    {

    }
    public void reactToGhost()
    {

    }
    public void reactToInteractable()
    {

    }
    public void getFeared()
    {

    }
}
