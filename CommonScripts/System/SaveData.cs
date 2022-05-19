[System.Serializable]
public struct SaveData
{
    public int highScore;
    public float masterVolume;
    public float bgmVolume;
    public float seVolume;

    public SaveData(int hscore, float mas, float bgm, float se)
    {
        highScore = hscore;
        masterVolume = mas;
        bgmVolume = bgm;
        seVolume = se;
    }

    public SaveData(SaveData data)
    {
        this.highScore = data.highScore;
        this.masterVolume = data.masterVolume;
        this.bgmVolume = data.bgmVolume;
        this.seVolume = data.seVolume;
    }
}