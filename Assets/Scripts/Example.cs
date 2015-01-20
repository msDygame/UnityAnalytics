using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour 
{
    public string sDebug = "...";
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
        GUI.Label(new Rect(10, 310, 600, 20), sDebug);
        if (GUI.Button(new Rect( 10, 10, 190, 90), "User is a Boy"))
        {            
            int iYear = UnityEngine.Random.Range(1, 10000);
            UnityAnalyticsIntegration.Instance().UserData(0,iYear,0,"smith");
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog() ;
        }
        if (GUI.Button(new Rect(210, 10, 190, 90), "User is a Girl"))
        {
            int iYear = UnityEngine.Random.Range(1, 10000);
            UnityAnalyticsIntegration.Instance().UserData(1, iYear, 0, "Mary");
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(410, 10, 190, 90), "User is a Unknown"))
        {
            int iYear = UnityEngine.Random.Range(1, 10000);
            UnityAnalyticsIntegration.Instance().UserData(2, iYear, 0, "Forsaken");
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(10, 110, 190, 90), "Event:GameStart"))
        {
            int iMoney = UnityEngine.Random.Range(1, 1000);
            UnityAnalyticsIntegration.Instance().Customized("GameStart","how many money?",iMoney) ;
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(210, 110, 190, 90), "Event:VersionCheck"))
        {
            string s = Application.unityVersion ;
            UnityAnalyticsIntegration.Instance().Customized("VersionCheck", "unity version=", s);
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(410, 110, 190, 90), "Event:GameVersionCheck"))
        {
            string s = "1.0.0.1";
            UnityAnalyticsIntegration.Instance().Customized("VersionCheck", "game version=", s);
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(610, 110, 190, 90), "Event:GameQuit"))
        {
            int iCount = UnityEngine.Random.Range(1, 10);
            UnityAnalyticsIntegration.Instance().Customized("GameQuit", "how many times dies?", iCount);
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
            //
            Application.Quit();
        }
        if (GUI.Button(new Rect(10, 210, 190, 90), "User Buy item 1"))
        {   
            int iCount = UnityEngine.Random.Range(1, 10);
            for (int i = 0; i < iCount; i++)
            {
                int iMoney = UnityEngine.Random.Range(1, 1000);
                UnityAnalyticsIntegration.Instance().Advanced("noodles", iMoney, "TWD");
            }
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(210, 210, 190, 90), "User Buy item 2"))
        {
            int iCount = UnityEngine.Random.Range(1, 10);
            for (int i = 0; i < iCount; i++)
            {
                int iMoney = UnityEngine.Random.Range(1, 40);
                UnityAnalyticsIntegration.Instance().Advanced("sodawater", iMoney, "USD");
            }
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(410, 210, 190, 90), "User Buy item 3"))
        {
            int iCount = UnityEngine.Random.Range(1, 10);
            for (int i = 0; i < iCount; i++)
            {
                int iMoney = UnityEngine.Random.Range(1, 200);
                UnityAnalyticsIntegration.Instance().Advanced("oil", iMoney, "RMB");
            }
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
        if (GUI.Button(new Rect(610, 210, 190, 90), "User Buy item 4"))
        {
            int iCount = UnityEngine.Random.Range(1, 10);
            for (int i = 0; i < iCount; i++)
            {
                int iMoney = UnityEngine.Random.Range(1, 20000);
                UnityAnalyticsIntegration.Instance().Advanced("gold", iMoney, "DYCoin");
            }
            sDebug = UnityAnalyticsIntegration.Instance().DebugLog();
        }
	}
}
