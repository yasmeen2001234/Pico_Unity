using UnityEngine;

public static class ScriptRemover  

{ 
    public static void DestroyAllScripts(this GameObject gameObject)
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            // Check if the component is not null and is not the Transform component
            if (script != null && !(script is Transform))
            {
                // Destroy the script
                Object.Destroy(script);
            }
        }
    }
    public static void DestroyAllScriptsAfterDelay(this GameObject gameObject)
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            // Check if the component is not null and is not the Transform component
            if (script != null && !(script is Transform))
            {
                // Destroy the script
                Object.Destroy(script , 0.15f);
            }
        }
    }
}
