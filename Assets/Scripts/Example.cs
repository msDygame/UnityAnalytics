using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour 
{
    protected bool IsInit = false;
    protected bool IsRandom = true;
	void Awake()
    {
    }

	// Use this for initialization
	void Start () 
    {
    
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	void OnGUI()
	{
        if (IsInit == false)
        {
            if (GUI.Button(new Rect(10,  10, 450, 90), "Analytics Project Unity461Analytics")) UnityAnalyticsIntegration.Instance().Initialize(1);
            if (GUI.Button(new Rect(10, 110, 450, 90), "Analytics Project TestUnityAnalytics")) UnityAnalyticsIntegration.Instance().Initialize(2);
            if (GUI.Button(new Rect(10, 210, 450, 90), "Analytics Project UnityAnalyticsTestPC")) UnityAnalyticsIntegration.Instance().Initialize(3);
            if (GUI.Button(new Rect(10, 310, 450, 90), "Analytics Project UnityAnalyticsTestVPN")) UnityAnalyticsIntegration.Instance().Initialize(4);
            if (GUI.Button(new Rect(10, 410, 450, 90), "Analytics Project UnityAnalyticsTestWifi")) UnityAnalyticsIntegration.Instance().Initialize(5);
            if (GUI.Button(new Rect(10, 510, 450, 90), "Analytics Project UnityAnalyticsTestAndroid")) UnityAnalyticsIntegration.Instance().Initialize(6);
            IsInit = UnityAnalyticsIntegration.Instance().DoOnce();
        }
        else
        {
            if (GUI.Button(new Rect(10, 10, 190, 90), "Set User Data"))
            {
                int iGender = UnityEngine.Random.Range(0, 3);//M,F,U
                int iYear = UnityEngine.Random.Range(1, 10000);//1~9999
                int iRandomName = UnityEngine.Random.Range(1, 6);//1~5
                string sName = "";
                //Test UserID 是否影響 newUser
                if (iRandomName == 1) sName = "smith";
                else if (iRandomName == 2) sName = "mary";
                else if (iRandomName == 3) sName = "Frog";
                else if (iRandomName == 4) sName = "john";
                else if (iRandomName == 5) sName = "mist";
                UnityAnalyticsIntegration.Instance().UserData(iGender, iYear, 0, sName);
            }
            if (GUI.Button(new Rect(210, 10, 190, 90), "Event:Quit"))
            {
                int iCount = UnityEngine.Random.Range(1, 10);
                UnityAnalyticsIntegration.Instance().Customized("GameQuit", "how many times dies?", iCount);
                //
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            }
            if (GUI.Button(new Rect(10, 110, 190, 90), "Event:GameStart"))
            {
                int iMoney = UnityEngine.Random.Range(1, 1000);
                UnityAnalyticsIntegration.Instance().Customized("GameStart", "how many money?", iMoney);
            }
            if (GUI.Button(new Rect(210, 110, 190, 90), "Event:VersionCheck"))
            {
                string s = Application.unityVersion;
                UnityAnalyticsIntegration.Instance().Customized("VersionCheck", "unity version=", s);
            }
            if (GUI.Button(new Rect(410, 110, 190, 90), "Event:GameVersionCheck"))
            {
                string s = "1.0.0.1";
                UnityAnalyticsIntegration.Instance().Customized("VersionCheck", "game version=", s);
            }
            if (GUI.Button(new Rect(10, 210, 190, 90), "User Buy item 1"))
            {
                int iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    int iMoney = UnityEngine.Random.Range(1, 1000);
                    UnityAnalyticsIntegration.Instance().Advanced("noodles", iMoney, "TWD");
                }
            }
            if (GUI.Button(new Rect(210, 210, 190, 90), "User Buy item 2"))
            {
                int iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    int iMoney = UnityEngine.Random.Range(1, 40);
                    UnityAnalyticsIntegration.Instance().Advanced("sodawater", iMoney, "USD");
                }
            }
            if (GUI.Button(new Rect(410, 210, 190, 90), "User Buy item 3"))
            {
                int iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    int iMoney = UnityEngine.Random.Range(1, 200);
                    UnityAnalyticsIntegration.Instance().Advanced("oil", iMoney, "DYCoin");
                }
            }
            string sTitle = (IsRandom) ? "Buy Random Count Item" : "Buy Single Item" ;
            if (GUI.Button(new Rect(10, 310, 190, 90), sTitle)) IsRandom = !IsRandom;            
        }
	}
}
