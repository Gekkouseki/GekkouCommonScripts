/// <summary>
/// ゲームデータのやりとり、実態を持つ
/// </summary>
public class SaveSystemManager : SingletonMonobehavior<SaveSystemManager>
{
    private SaveData saveData;

    public SaveData SaveData { get { return saveData; } }

    /* テンプレート
    public void Saving()
    {
        var data = new SaveData(saveData);

        //　セーブデータの上書きを行う

        Saving(data);

        saveData = new SaveData(data);
    }
    */

    public void Saving(int highScore)
    {
        var data = new SaveData(saveData);

        data.highScore = highScore;

        Saving(data);

        saveData = new SaveData(data);
    }

    public void Saving(float master, float bgm, float se)
    {
        var data = new SaveData(saveData);

        data.masterVolume = master;
        data.bgmVolume = bgm;
        data.seVolume = bgm;

        Saving(data);

        saveData = new SaveData(data);
    }

    public void Saving(SaveData data)
    {
        SaveSystemPlayerPrefs<SaveData>.SavingGameData(data);
    }

    public void Loading()
    {
        saveData = SaveSystemPlayerPrefs<SaveData>.LoadingGameData();
    }

    protected override void Awake()
    {
        base.Awake();
        Loading();
    }
}
