using MiniExcelLibs;
using System.Collections.Generic;
using System.IO;

using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace NFLPredictionData.Pages;
using NFLPredictionData.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReadExcelFileModel: PageModel
{
    public void OnGet()
    {
        /*
        string filePath = "records.xlsx";

        // This single line reads the sheet and binds it to your model list
        IEnumerable<UserModel> users = MiniExcel.Query<UserModel>(filePath);

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name} ({user.Age}): {user.Email}");
        }
        */
    }
}