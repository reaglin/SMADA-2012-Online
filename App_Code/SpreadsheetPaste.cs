using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace SMADA_2012.App_Code
{
    public class SpreadsheetPaste
    {

        public const char ColumnDelimiter = '\t';
        public const char RowDelimiter = '\n';

        public static List<T> GetData<T>(string content)
        {
            List<T> value = new List<T>();
            T obj;
            string[] rowValues;
            string[] colValues;
            int colIndex = 0;
            PropertyInfo pInfo;

            if (string.IsNullOrEmpty(content) || content == "null")
                return null;

            content = content.Replace("\r", "");
            rowValues = content.Split(RowDelimiter);

            foreach (string rowItem in rowValues)
            {
                if (string.IsNullOrEmpty(rowItem))
                    continue;

                colValues = new string[rowItem.Split(ColumnDelimiter).Length];
                colIndex = 0;
                obj = (T)Activator.CreateInstance(typeof(T));

                foreach (string colItem in rowItem.Split(ColumnDelimiter))
                {
                    pInfo = obj.GetType().GetProperties()[colIndex];
                    pInfo.SetValue(obj, colItem, null);
                    colIndex++;
                }
                value.Add(obj);
            }

            return value;
        }

        public static DataTable GetDataTable(string content, bool IsFirstColumnHeader)
        {
            DataTable value = new DataTable();
            string[] rowValues;
            string[] colValues;
            int colIndex = 0;
            int rowIndex = 0;

            if (string.IsNullOrEmpty(content) || content == "null")
                return null;

            content = content.Replace("\r", "");
            rowValues = content.Split(RowDelimiter);

            foreach (string rowItem in rowValues)
            {
                if (string.IsNullOrEmpty(rowItem))
                    continue;

                string trimmedRowItem = rowItem.TrimEnd('\t');
                colValues = new string[trimmedRowItem.Split(ColumnDelimiter).Length];
                colIndex = 0;

                foreach (string colItem in trimmedRowItem.Split(ColumnDelimiter))
                {
                    if (rowIndex == 0 && IsFirstColumnHeader)
                        value.Columns.Add(colItem);
                    else if (rowIndex == 0)
                        value.Columns.Add();

                    if ((rowIndex == 0 && !IsFirstColumnHeader) || rowIndex != 0)
                        colValues[colIndex] = colItem;

                    colIndex++;
                }
                if ((rowIndex == 0 && !IsFirstColumnHeader) || rowIndex != 0)
                    value.Rows.Add(colValues);

                rowIndex++;
            }

            return value;
        }

        public static DataTable GetDataTable(string content, string[] headers)
        {
            DataTable value = new DataTable();
            string[] rowValues;
            string[] colValues;
            int colIndex = 0;

            if (string.IsNullOrEmpty(content) || content == "null")
                return null;

            content = content.Replace("\r", "");
            rowValues = content.Split(RowDelimiter);

            foreach (string h in headers)
            {
                value.Columns.Add(h);
            }

            foreach (string rowItem in rowValues)
            {
                if (!string.IsNullOrEmpty(rowItem))
                {

                    string trimmedRowItem = rowItem.TrimEnd('\t');
                    colValues = new string[trimmedRowItem.Split(ColumnDelimiter).Length];
                    colIndex = 0;
                    foreach (string colItem in trimmedRowItem.Split(ColumnDelimiter))
                    {
                        colValues[colIndex] = colItem;
                        colIndex++;
                    }
                    value.Rows.Add(colValues);
                }
            }
            return value;
        }

        public static string convertToTabDelimited(string s)
        {
            string t = s;

            t = t.TrimEnd(' ');
            t = t.TrimEnd('\n');
            while (t.Contains("  "))
            {
                t = t.Replace("  ", " ");
            }
            t = t.Replace(" ,", ",");
            t = t.Replace(", ", ",");
            t = t.Replace(" ;", ";");
            t = t.Replace("; ", ";");
            t = t.Replace(" \t", "\t");
            t = t.Replace("\t ", "\t");
            t = t.Replace(",", "\t");
            t = t.Replace(" ", "\t");
            t = t.Replace(";", "\t");
            return t;
        }
    }


    public class TestData
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}