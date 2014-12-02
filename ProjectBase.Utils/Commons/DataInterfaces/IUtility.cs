using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Components;
using System.Web.Configuration;
using System.Globalization;

namespace ProjectBase.Utils.Commons
{
    public interface IUtility
    {
        // Property
        GlobalizationSection Globalization { get; }
        CultureInfo Culture { get; }
        CultureInfo EngCulture { get; }
        CultureInfo ThaCulture { get; }

        // Method
        string GetDayName(DayOfWeek dayOfWeek);
        string GetEngMonthName(int month);
        string GetThaMonthName(int month);
        DateTime GetFirstDayOfMonth(DateTime currentDate);
        DateTime GetLastDayOfMonth(DateTime currentDate);
        string GetDatetime(IValueValidation iDatetime);
        string GetDatetime(IValueValidation iDatetime, string format);
        string GetDatetime(IValueValidation iDatetime, string format, IFormatProvider provider);
        string GetDateInterval(IValueValidation iStartDatetime, IValueValidation iEndDatetime);
        string GetDateInterval(IValueValidation iStartDatetime, IValueValidation iEndDatetime, string format);
        string GetDateInterval(IValueValidation iStartDatetime, IValueValidation iEndDatetime, string format, IFormatProvider provider);
        string GetHashedPass(string password, string passwordFormat);
        string AddSeparatorInArray<T>(T[] arrValue, object separator);
        void SendEmail(string emailTo, string emailSubject, string emailBody, string emailUser, string emailPassword);

        // Use for upload file
        string GetDefineFileName(string fileName, string name);
        void SaveFileToServer(string path, byte[] bytes);
        void DeleteFileInServer(string filePath);
        void DeleteAllFileInDirectory(string directoryPath);
        void CopyFileInServer(string sourceFilePath, string destFilePath);
        void BackUpFileInServer(string sourceFilePath);
    }
}
