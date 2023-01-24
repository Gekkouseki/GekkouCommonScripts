using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gekkou
{
    /// <summary>
    /// EnumEdior表示用
    /// </summary>
    public class EnumEditorWindow : EditorWindow
    {
        private string _enumName = "EnumName";
        [SerializeField]
        private List<string> _itemNameList = new List<string>();
        private bool _isNumber = false;
        private int _itemStartNumber = 0;
        private string _filePath = "";
        private string _fileSummary = "";

        [MenuItem("Tools/Gekkou/Window/EnumEditor")]
        private static void Open()
        {
            var window = GetWindow<EnumEditorWindow>();
            window.titleContent = new GUIContent("Enum Editor");
        }

        private void FindFilePath()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                _filePath = FileExporter.DEFAULT_PATH;
            }
            _filePath = EnumEditor.FindPath(_enumName, _filePath);
        }

        private void CreateEnumFile()
        {
            EnumEditor.Create(_enumName, _itemNameList, _filePath, _fileSummary, _isNumber, _itemStartNumber);
        }

        private void OnGUI()
        {
            var win = new SerializedObject(this);
            win.Update();

            EditorGUILayout.BeginVertical("Box");
            {
                EditorGUILayout.LabelField("Enum Data");
                _enumName = EditorGUILayout.TextField("Enum Name", _enumName);
                EditorGUILayout.PropertyField(win.FindProperty("_itemNameList"), true);
                _isNumber = EditorGUILayout.Toggle("Is Number", _isNumber);
                if (_isNumber)
                {
                    _itemStartNumber = EditorGUILayout.IntField("Item Start Number", _itemStartNumber);
                }
                EditorGUILayout.LabelField("File Summary");
                _fileSummary = EditorGUILayout.TextArea(_fileSummary, GUILayout.Height(90.0f));
            }
            EditorGUILayout.EndVertical();

            if (GUILayout.Button("Create Enum File"))
            {
                FindFilePath();
                if (!string.IsNullOrEmpty(_filePath))
                {
                    CreateEnumFile();
                }
            }

            win.ApplyModifiedProperties();
        }

    }

}
