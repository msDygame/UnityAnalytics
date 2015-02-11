using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour 
{
    protected bool IsInit = false;
    protected bool IsRandom = true;
    protected int  iCount = 1;
    protected int  iMoney = 0;
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
                //Test UserID 是否影響 newUser ;//已證明:沒影響
                if (iRandomName == 1) sName = "smith";
                else if (iRandomName == 2) sName = "mary";
                else if (iRandomName == 3) sName = "Frog";
                else if (iRandomName == 4) sName = "john";
                else if (iRandomName == 5) sName = "mist";
                int iLogLevel = 0;//LogLevel.Error
                UnityAnalyticsIntegration.Instance().UserData(iGender, iYear, iLogLevel, sName);
            }
            if (GUI.Button(new Rect(210, 10, 190, 90), "Event:Quit"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
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
                iMoney = UnityEngine.Random.Range(1, 1000);
                UnityAnalyticsIntegration.Instance().Customized("GameStart", "how many money?", iMoney);
            }
            if (GUI.Button(new Rect(210, 110, 190, 90), "Event:UserLevelCheck"))
            {
                //已證明:自定義事件不能儲存字串,它只有sum和count(for DAU),和average
                int iLevel = UnityEngine.Random.Range(1, 101);//1~100
                UnityAnalyticsIntegration.Instance().Customized("LevelCheck", "User Level=", iLevel);
            }
            if (GUI.Button(new Rect(10, 210, 190, 90), "User Buy TWD 1"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    iMoney = UnityEngine.Random.Range(1, 1000);
                    UnityAnalyticsIntegration.Instance().Advanced("food", iMoney, "TWD");
                }
            }
            if (GUI.Button(new Rect(210, 210, 190, 90), "User Buy USD 2"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    iMoney = UnityEngine.Random.Range(1, 40);
                    UnityAnalyticsIntegration.Instance().Advanced("water", iMoney, "USD");
                }
            }
            if (GUI.Button(new Rect(410, 210, 190, 90), "User Buy coin 3"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    iMoney = UnityEngine.Random.Range(1, 200);
                    UnityAnalyticsIntegration.Instance().Advanced("oil", iMoney, "DYCoin");
                }
            }
            if (GUI.Button(new Rect(10, 310, 190, 90), "User Buy Custom 4"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    iMoney = UnityEngine.Random.Range(1, 1000);
                    UnityAnalyticsIntegration.Instance().Customized("Buy weapon", "Use DYcoin=", iMoney);
                }
            }
            if (GUI.Button(new Rect(210, 310, 190, 90), "User Buy Custom 5"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    iMoney = UnityEngine.Random.Range(1, 1000);
                    UnityAnalyticsIntegration.Instance().Customized("Buy weapon", "Use gold=", iMoney);
                }
            }
            if (GUI.Button(new Rect(410, 310, 190, 90), "User Buy Custom 6"))
            {
                iCount = UnityEngine.Random.Range(1, 10);
                if (!IsRandom) iCount = 1;
                for (int i = 0; i < iCount; i++)
                {
                    iMoney = UnityEngine.Random.Range(1, 1000);
                    UnityAnalyticsIntegration.Instance().Customized("Buy armor", "Use DYcoin=", iMoney);
                }
            }
            string sTitle = "Buy " + iCount + " Item=" + iMoney ;
            if (GUI.Button(new Rect(10, 410, 190, 90), sTitle)) { IsRandom = !IsRandom; if (!IsRandom) iCount = 1; }
            if (GUI.Button(new Rect(210, 410, 190, 90), "Customized Test Max 50"))
            {
                UnityAnalyticsIntegration.Instance().CustomizedTestLimit("Buy armor");
            }
        }
	}
}
