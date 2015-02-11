using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;
using System.Collections.Generic;//for Dictionary
public class UnityAnalyticsIntegration : MonoBehaviour 
{
    // appID is created from https://analytics.cloud.unity3d.com/ , 
    // step1: create a account 
    // step2: add a project name , then get a ProjectId.
    public string appId1 = "e84c3ea1982c41258df800e8e9573b8a";//test project 1 = "Unity461Analytics"
    public string appId2 = "df9f1696019f99b75fc4fda400890005";//test project 2 = "TestUnityAnalytics"
    public string appId3 = "7c9c2abdad399763bf10c8e9678977f6";//test project 3 = "UnityAnalyticsTestPC" ;
    public string appId4 = "2d044d3069f1aa4df810ddad7b6d9eab";//test project 4 = "UnityAnalyticsTestVPN" ;
    public string appId5 = "7d9a8f0a4bae3f16a9094705a300f6fe";//test project 5 = "UnityAnalyticsTestWifi" ;
    public string appId6 = "f8c97b854b71f42c39c6e415778e7401";//test project 6 = "UnityAnalyticsTestAndroid" ;
    protected bool IsDoOnce = false;
    protected string UserId = "" ;
    //self
    protected static UnityAnalyticsIntegration Self;
    //
    void Awake()
    {
    }
    // Use this for initialization
    void Start () 
    {
        Self = this;
        /*
         * 把腳本貼在物件上
         * 這支程式會初始化Analytics SDK並開始蒐集數據，你可以將這隻程式貼到任一場景裡的物件上來初始化分析流程。(記得appID要改成你自己的)
         * 為了獲取越齊全的數據，我們建議把這隻程式貼在你遊戲一進來的第一個場景裡。
         * 要把程式貼到物件上只要從Project介面把AnalyticsIntegration這支程式拖到Scene介面上的物件(例如Main Camera)上即可。
         UnityAnalytics.StartSDK(appId);
         */        
    }
    // Update is called once per frame
    void Update () 
    {
	
	}
    //
    void OnGUI()
    {
    }
    //Instance 
    public static UnityAnalyticsIntegration Instance()
    {
        return Self;
    }
    //init UnityAnalytics
    public void Initialize(int iSellectAppId)
    {
        if (IsDoOnce) return;
        //
        string appId = "";
        if (iSellectAppId == 1) appId = string.Copy(appId1);
        else if (iSellectAppId == 2) appId = string.Copy(appId2);
        else if (iSellectAppId == 3) appId = string.Copy(appId3);
        else if (iSellectAppId == 4) appId = string.Copy(appId4);
        else if (iSellectAppId == 5) appId = string.Copy(appId5);
        else if (iSellectAppId == 6) appId = string.Copy(appId6);
        UnityAnalytics.StartSDK(appId);
        IsDoOnce = true;
    }
    //
    public bool DoOnce() { return IsDoOnce;  }
    // Use this call for each and every place that a player triggers a monetization event
    public void Advanced(string productId, decimal price, string currency)
    {                
        //進階用法 - 分析使用者消費習慣
        /* 
         *  Unity Analytics提供了一個方便的方法來分析玩家的消費習慣，這事件需要在玩家購買金幣或虛寶的時候被觸發。
         *  交易函式需要一個價格參數、貨幣幣別和Apple iTunes或是Google play辨識字串。
         *  UnityAnalytics.Transaction(string productId, decimal price, string currency, string receipt,  string signature);
         *  productId	string	物品ID
            price       decimal	物品價格
            currency	string	幣別. 例如 “TWD” ,從這個網頁可以查幣別http://en.wikipedia.org/wiki/ISO_4217
            receipt     string	iOS或android用來和平台驗證的編號. 如果是Null值代表不使用
            signature	string	Android數位簽章. 如果使用原生的Android應用包含開發商的密鑰 INAPP_DATA_SIGNATURE參數，數據簽名使用 RSASSA-PKCS1-v1_5 加密規則. 如果是Null值代表不使用.
         *  這個範例代表買了一個編號為12345abcde的物品，0.99美金，沒有簽章
         *  UnityAnalytics.Transaction("12345abcde", 0.99m, "USD", null, null);
         *  自定義貨幣無法被記錄，例如： ”DyGold”,收入會是0 。
         */
        UnityAnalytics.Transaction(productId, price, currency, null, null);
    }
    //
    public void Customized(string customEventName, string eventDictionaryKey, object eventDictionaryValue)
    {
        //進階用法 - 自訂事件
        /*  Unity Analytics可以透過遊戲內設定好自訂事件來分析客製化的數據，例如你自己的渠道分析、紀錄玩家的遊戲行為，或是紀錄分析里程碑等等。
         *  UnityAnalytics.CustomEvent(string customEventName, IDictionary<string, object> eventData);
         *  customEventName	string      自訂事件名稱，名稱不能有包含"unity."的描述 - 這是一個保留字
         *  Dictionary      dictionary	事件的附加參數，名稱不能有包含"unity."的描述 - 這是一個保留字
         *  1.每個自訂事件預設最多10個參數 - 超過會有AnalyticsResult.TooManyItems的錯誤。
         *  2.Dictionary欄位最多500字 - 超過會有AnalyticsResult.SizeLimitReached的錯誤。
         *  3.每個帳號最多100個自訂事件 - 超過會有AnalyticsResult.TooManyRequests的錯誤。要注意的是，Unity Analytics只會處理前50個自訂事件
         *  (Default limit of 100 custom events per hour, per user.Please note that Unity Analytics will only process the first 50 unique custom event names.)         
            如果你有51個關卡，並希望每個關卡都有自訂事件，Unity Analytics只會處理前50個關卡資料，如果你要解除這個限制，你可以用一些作法來實現。
            例如:你可以用一個"LEVELNUM"當作事件參數，傳遞給自訂事件的"LEVEL"，例如"LEVEL1","LEVEL2"...，你可以建立一個LEVEL自訂事件就能解決這樣的需求。
         *  這個範例可以分析玩家死掉的時候包包裡的物品狀況
            int totalPotions = 5;
            int totalCoins = 100;
            UnityAnalytics.CustomEvent("gameOver", new Dictionary<string, object>
            {
                { "potions", totalPotions },
                { "coins", totalCoins }
            });
         *  自定義事件不能儲存字串,它只有sum和count和average。
         */
        UnityAnalytics.CustomEvent(customEventName, new Dictionary<string, object>
        {
            { eventDictionaryKey, eventDictionaryValue }
        });
    }
    public void CustomizedTestLimit(string customEventName)
    {
        UnityAnalytics.CustomEvent(customEventName, new Dictionary<string, object>
        {
            { "Potions"  ,    5 },
            { "Coins"    ,  100 },
            { "Oil"      , 9876 }, 
            { "Gold"     , 5555 }, 
            { "Iron"     , 4000 },
            { "Wood"     , 3200 },
            { "Silk"     , 2015 },
            { "Steel"    , 1510 },
            { "Water"    , 2048 },
            { "Silver"   , 1024 },
            { "Bullet"   , 4096 },
            { "Copper"   , 65536},
            { "Platinum" , 9527 }, 
            { "Aluminum" , 8848 },//14
            { "Level_15" , 1005 },
            { "Level_16" , 1100 },
            { "Level_17" , 9876 }, 
            { "Level_18" , 5555 }, 
            { "Level_19" , 4000 },
            { "Level_20" , 3200 },
            { "Level_21" , 2015 },
            { "Level_22" , 1510 },
            { "Level_23" , 2048 },
            { "Level_24" , 1024 },
            { "Level_25" , 4096 },
            { "Level_26" , 6553 },
            { "Level_27" , 9527 },
            { "Level_28" , 8848 },
            { "Level_29" , 1005 },
            { "Level_30" , 1100 },
            { "Level_31" , 9876 }, 
            { "Level_32" , 5555 }, 
            { "Level_33" , 4000 },
            { "Level_34" , 3200 },
            { "Level_35" , 2015 },
            { "Level_36" , 1510 },
            { "Level_37" , 2048 },
            { "Level_38" , 1024 },
            { "Level_39" , 4096 },
            { "Level_40" , 6553 },
            { "Level_41" , 9527 },
            { "Level_42" , 8848 },
            { "Level_43" , 2048 },
            { "Level_44" , 1024 },
            { "Level_45" , 4096 },
            { "Level_46" , 6553 },
            { "Level_47" , 9527 },
            { "Level_48" , 8848 },
            { "Level_49" , 1005 },
            { "Level_50" , 1100 },
            { "Level_51" , 9876 }
        });
    }
    //
    public void UserData(int iUserGender, int iYear, int iLogLevel , string sUserID)
    {
        //進階用法 - 人口統計
        //性別可以是"F", "M", 或 "U".
        SexEnum gender = SexEnum.U;
        if (iUserGender == 0) gender = SexEnum.M;
        if (iUserGender == 1) gender = SexEnum.F;
        //哪一年出生，必須是4個數字        
        if (iYear < 0) iYear = 0;
        if (iYear > 10000) iYear = 9999;
        int birthYear = iYear;
        //save the custom UserID
        UserId = string.Copy(sUserID);
        //
        LogLevel DefaultLogLevel = LogLevel.None;
        if (iLogLevel == 0) DefaultLogLevel = LogLevel.Error;
        if (iLogLevel == 1) DefaultLogLevel = LogLevel.Warning;
        if (iLogLevel == 2) DefaultLogLevel = LogLevel.Info;
        bool bEnable = true;
        if (DefaultLogLevel == LogLevel.None) bEnable = false;
        //
        UnityAnalytics.SetUserGender(gender);
        UnityAnalytics.SetUserBirthYear(birthYear);
        UnityAnalytics.SetLogLevel(DefaultLogLevel, bEnable);
        UnityAnalytics.SetUserId(UserId);
    }
}
