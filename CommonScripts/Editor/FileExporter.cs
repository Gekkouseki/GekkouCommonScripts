using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public static class FileExporter
{
    public static readonly string DEFAULT_PATH = "Assets/Scripts/";
    public static readonly string DEFAULT_EXTENSION = ".cs";

    /// <summary>
    /// デフォルトで用意されたファイルパスを生成します
    /// </summary>
    public static string CreateFilePath(string fileName)
    {
        return new StringBuilder(DEFAULT_PATH).Append(fileName).Append(DEFAULT_EXTENSION).ToString();
    }

    /// <summary>
    /// 実行中かどうかを判定し、作成可能か取得
    /// </summary>
    public static bool CanCreate()
    {
        return !EditorApplication.isPlaying
            && !Application.isPlaying
            && !EditorApplication.isCompiling;
    }

    /// <summary>
    /// 入力された内容を出力する
    /// </summary>
    public static void FileExport(string fileData, string filePath, string coment = "Export")
    {
        var directoryName = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        File.WriteAllText(filePath, fileData, Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);

        EditorUtility.DisplayDialog("File Export", coment, "OK");
    }
}
