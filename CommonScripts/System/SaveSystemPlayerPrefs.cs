using UnityEngine;

/// <summary>
/// ゲームデータの書き込み、読み込みを行う
/// </summary>
/// <typeparam name="T"></typeparam>
public class SaveSystemPlayerPrefs<T> where T : struct
{
    private static readonly string SAVEKEY = "SAVEDATA";

    public static void SavingGameData(T argData)
    {
        // json化
        var json = JsonUtility.ToJson(argData);

        // 保存
        PlayerPrefs.SetString(SAVEKEY, json);

        // 強制保存
        PlayerPrefs.Save();
    }

    public static T LoadingGameData()
    {
        if (PlayerPrefs.HasKey(SAVEKEY))
        {
            // セーブデータが存在する
            var json = PlayerPrefs.GetString(SAVEKEY);

            // T化
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            // セーブデータが存在しない
            return new T();
        }
    }
}
