using System;
using System.Collections.Generic;
using Complex.Task1.ThirdParty;

namespace Complex.Task1
{
    public class Print : ICommand
    {
        private readonly IDatabaseManager manager;
        private readonly IView view;
        private string tableName;

        public Print(IView view, IDatabaseManager manager)
        {
            this.view = view;
            this.manager = manager;
        }

        public bool CanProcess(string command)
        {
            return command.StartsWith("print ");
        }

        public void Process(string command)
        {
            var commandPart = command.Split(' ');
            if (commandPart.Length != 2)
                throw new ArgumentException(
                    "incorrect number of parameters. Expected 1, but is " + (commandPart.Length - 1));
            tableName = commandPart[1];
            var data = manager.GetTableData(tableName);
            view.Write(GetTableString(data));
        }

        private string GetTableString(IList<IDataSet> data)
        {
            var maxColumnSize = GetMaxColumnSize(data);
            if (maxColumnSize == 0)
                return GetEmptyTable(tableName);
            else
                return GetHeaderOfTheTable(data) + GetStringTableData(data);
        }

        private string GetEmptyTable(string tableName)
        {
            var textEmptyTable = "║ Table '" + tableName + "' is empty or does not exist ║";
            var result = "╔";
            for (var i = 0; i < textEmptyTable.Length - 2; i++)
                result += "═";
            result += "╗\n";
            result += textEmptyTable + "\n";
            result += "╚";
            for (var i = 0; i < textEmptyTable.Length - 2; i++)
                result += "═";
            result += "╝\n";
            return result;
        }

        private int GetMaxColumnSize(IList<IDataSet> dataSets)
        {
            var maxLength = 0;
            if (dataSets.Count > 0)
            {
                var columnNames = dataSets[0].GetColumnNames();
                foreach (var columnName in columnNames)
                    if (columnName.Length > maxLength)
                        maxLength = columnName.Length;
                foreach (var dataSet in dataSets)
                {
                    var values = dataSet.GetValues();
                    foreach (var value in values)
                        //                      if (value is String)
                        if (value.ToString().Length > maxLength)
                            maxLength = value.ToString().Length;
                }
            }
            return maxLength;
        }

        private string GetStringTableData(IList<IDataSet> dataSets)
        {
            var rowsCount = dataSets.Count;
            var maxColumnSize = GetMaxColumnSize(dataSets);
            var result = "";
            if (maxColumnSize % 2 == 0)
                maxColumnSize += 2;
            else
                maxColumnSize += 3;
            var columnCount = GetColumnCount(dataSets);
            for (var row = 0; row < rowsCount; row++)
            {
                var values = dataSets[row].GetValues();
                result += "║";
                for (var column = 0; column < columnCount; column++)
                {
                    var valuesLength = values[column].ToString().Length;
                    if (valuesLength % 2 == 0)
                    {
                        for (var j = 0; j < (maxColumnSize - valuesLength) / 2; j++)
                            result += " ";
                        result += values[column].ToString();
                        for (var j = 0; j < (maxColumnSize - valuesLength) / 2; j++)
                            result += " ";
                        result += "║";
                    }
                    else
                    {
                        for (var j = 0; j < (maxColumnSize - valuesLength) / 2; j++)
                            result += " ";
                        result += values[column].ToString();
                        for (var j = 0; j <= (maxColumnSize - valuesLength) / 2; j++)
                            result += " ";
                        result += "║";
                    }
                }
                result += "\n";
                if (row < rowsCount - 1)
                {
                    result += "╠";
                    for (var j = 1; j < columnCount; j++)
                    {
                        for (var i = 0; i < maxColumnSize; i++)
                            result += "═";
                        result += "╬";
                    }
                    for (var i = 0; i < maxColumnSize; i++)
                        result += "═";
                    result += "╣\n";
                }
            }
            result += "╚";
            for (var j = 1; j < columnCount; j++)
            {
                for (var i = 0; i < maxColumnSize; i++)
                    result += "═";
                result += "╩";
            }
            for (var i = 0; i < maxColumnSize; i++)
                result += "═";
            result += "╝\n";
            return result;
        }

        private int GetColumnCount(IList<IDataSet> dataSets)
        {
            var result = 0;
            if (dataSets.Count > 0)
                return dataSets[0].GetColumnNames().Count;
            return result;
        }

        private string GetHeaderOfTheTable(IList<IDataSet> dataSets)
        {
            var maxColumnSize = GetMaxColumnSize(dataSets);
            var result = "";
            var columnCount = GetColumnCount(dataSets);
            if (maxColumnSize % 2 == 0)
                maxColumnSize += 2;
            else
                maxColumnSize += 3;
            result += "╔";
            for (var j = 1; j < columnCount; j++)
            {
                for (var i = 0; i < maxColumnSize; i++)
                    result += "═";
                result += "╦";
            }
            for (var i = 0; i < maxColumnSize; i++)
                result += "═";
            result += "╗\n";
            var columnNames = dataSets[0].GetColumnNames();
            for (var column = 0; column < columnCount; column++)
            {
                result += "║";
                var columnNamesLength = columnNames[column].Length;
                if (columnNamesLength % 2 == 0)
                {
                    for (var j = 0; j < (maxColumnSize - columnNamesLength) / 2; j++)
                        result += " ";
                    result += columnNames[column];
                    for (var j = 0; j < (maxColumnSize - columnNamesLength) / 2; j++)
                        result += " ";
                }
                else
                {
                    for (var j = 0; j < (maxColumnSize - columnNamesLength) / 2; j++)
                        result += " ";
                    result += columnNames[column];
                    for (var j = 0; j <= (maxColumnSize - columnNamesLength) / 2; j++)
                        result += " ";
                }
            }
            result += "║\n";

            //last string of the header
            if (dataSets.Count > 0)
            {
                result += "╠";
                for (var j = 1; j < columnCount; j++)
                {
                    for (var i = 0; i < maxColumnSize; i++)
                        result += "═";
                    result += "╬";
                }
                for (var i = 0; i < maxColumnSize; i++)
                    result += "═";
                result += "╣\n";
            }
            else
            {
                result += "╚";
                for (var j = 1; j < columnCount; j++)
                {
                    for (var i = 0; i < maxColumnSize; i++)
                        result += "═";
                    result += "╩";
                }
                for (var i = 0; i < maxColumnSize; i++)
                    result += "═";
                result += "╝\n";
            }
            return result;
        }
    }
}