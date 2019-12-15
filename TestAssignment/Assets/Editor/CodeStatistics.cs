using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CodeStatistics : MonoBehaviour
    {
        [MenuItem("Tools/Project tools/Code Statistics", priority = 1)]
        public static void MenuItemCSharpCodeStatistics()
        {
            var selection = Selection.GetFiltered(typeof(MonoScript), SelectionMode.DeepAssets);
            if (selection.Length > 0)
            {
                var data = new CodeStatisticData(selection.Length);
                foreach (var item in selection)
                    CodeStatisticsCalculate(data, item);

                EditorUtility.DisplayDialog("Statistics code", CodeStatisticToString(data), "OK");
            }
            else
                EditorUtility.DisplayDialog("Statistics code", "No scripts found", "OK");
        }

        private static void CodeStatisticsCalculate(CodeStatisticData data, Object itemSelectObject)
        {
            var currentScript = (MonoScript) itemSelectObject;
            int countLines = 0;
            data.linesTotal += MonoScriptCounterLines(currentScript, ref countLines);

            if (countLines > data.maxLength)
            {
                data.maxLength = countLines;
                data.max = currentScript.name;
            }

            if (countLines < data.minLength)
            {
                data.minLength = countLines;
                data.min = currentScript.name;
            }

            data.linesCode += countLines;
        }

        private static int MonoScriptCounterLines(MonoScript script, ref int countLines)
        {
            string[] linesScript = script.text.Split('\n');
            foreach (var currentLine in linesScript)
            {
                string cleanLine = currentLine.Trim();
                if (cleanLine.Length > 0 && !cleanLine.StartsWith("//"))
                    countLines++;
            }

            return linesScript.Length;
        }

        private static string CodeStatisticToString(CodeStatisticData data)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Statistics for " + ToStringGroup(data.length) + " selected scripts.");

            builder.AppendLine();
            builder.AppendLine($"Minimum file length: {data.minLength} ({data.min}); ");
            builder.AppendLine($"Maximum file length: {data.maxLength} ({data.max}); ");
            builder.AppendLine($"Average file length: {data.linesCode / data.length}");

            builder.AppendLine();
            builder.AppendLine($"Total lines: {ToStringGroup(data.linesCode)} ({ToStringGroup(data.linesTotal)}); ");

            return builder.ToString();
        }

        private class CodeStatisticData
        {
            public int linesTotal = 0;
            public int linesCode = 0;
            public int maxLength = int.MinValue;
            public int minLength = int.MaxValue;
            public string max = "";
            public string min = "";
            public readonly int length;

            public CodeStatisticData(int length)
            {
                this.length = length;
            }
        }

        private static string ToStringGroup(int length)
        {
            return length.ToString("### ### ##0").Trim();
        }
    }
}