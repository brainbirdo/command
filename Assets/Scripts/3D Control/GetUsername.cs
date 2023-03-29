using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetUsername : MonoBehaviour
{

    public static GetUsername Instance;
    public string username;

    public TMP_Text missionBrief;

    void Update()
    {
        missionBrief.SetText(username.ToUpper() + ",");
    }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;

        username = System.Environment.UserName;
    }

}
