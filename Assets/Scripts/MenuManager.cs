using UnityEditor.SearchService;
using UnityEngine;

public class MenuManager : MonoBehaviour
{


    public void ChangeScene(string SceneName)
    {

        SceneLoad.Instance.ChangeScene(SceneName);

    }




}
