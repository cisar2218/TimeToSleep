using UnityEngine;

public class NPCAfterDeathCallbacks : MonoBehaviour
{
    public void DeathAfterActions()
    {
        Debug.Log("NPC dead");
        // todo get NPC script that is on parent gameobject. Call KillAfterActions
        var npc = GetComponentInParent<NPC>();
        if (npc != null)
        {
            npc.KillAfterActions();
        }
    }
}
