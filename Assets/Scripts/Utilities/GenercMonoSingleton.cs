using UnityEngine;

public class GenercMonoSingleton<T> : MonoBehaviour where T : GenercMonoSingleton<T>
{
    public static T Instance { get { return instance; } }
    private static T instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("Singlton of " + (T)this + " is trying to create second Instance");
        }
    }

}
