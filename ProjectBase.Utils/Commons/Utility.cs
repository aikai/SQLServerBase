using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Configuration;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;
using ProjectBase.Utils;

namespace ProjectBase.Utils.Commons
{
    public class Utility : IUtility
    {
        public Utility() { }

        #region My attributes
        protected const string GLOBALIZATION = "system.web/globalization"; 
        #endregion

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static Utility Instance
        {
            get
            {
                try
                {
                    return Nested.Utils;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        protected class Nested
        {
            static Nested() { }
            internal static readonly Utility Utils = new Utility();
        }
        #endregion

        #region My properties
        public GlobalizationSection Globalization
        {
            get
            {
                try
                {
                    return WebConfigurationManager.GetSection(GLOBALIZATION) as GlobalizationSection;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public CultureInfo Culture
        {
            get
            {
                try
                {
                    return new CultureInfo(Globalization.Culture);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public CultureInfo EngCulture
        {
            get
            {
                try
                {
                    return new CultureInfo("en-US");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public CultureInfo ThaCulture
        {
            get
            {
                try
                {
                    return new CultureInfo("th-TH");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region My methods
        public string GetDayName(DayOfWeek dayOfWeek)
        {
            try
            {
                return Culture.DateTimeFormat.DayNames[(int)dayOfWeek];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetEngMonthName(int month)
        {
            try
            {
                return EngCulture.DateTimeFormat.MonthNames[month - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetThaMonthName(int month)
        {
            try
            {
                return ThaCulture.DateTimeFormat.MonthNames[month - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // หาวันแรกของเดือน จากวันปัจจุบัน  
        public DateTime GetFirstDayOfMonth(DateTime currentDate)
        {
            try
            {
                return new DateTime(currentDate.Year, currentDate.Month, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // หาวันสุดท้ายของเดือน จากวันปัจจุบัน  
        public DateTime GetLastDayOfMonth(DateTime currentDate)
        {
            try
            {
                return new DateTime(currentDate.Year, currentDate.Month,
                    DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDatetime(IValueValidation iDatetime)
        {
            try
            {
                var result = string.Empty;

                if (iDatetime != null && iDatetime.HasValue)
                {
                    var date = (DateTime)iDatetime.Value;

                    if (date != null)
                    {
                        var factFormat = ComponentFactory.Instance.CreateFormat();

                        result = date.ToString(factFormat.Date, Culture);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDatetime(IValueValidation iDatetime, string format)
        {
            try
            {
                var result = string.Empty;

                if (iDatetime != null && iDatetime.HasValue)
                {
                    var date = (DateTime)iDatetime.Value;

                    if (date != null)
                    {
                        result = date.ToString(format, Culture);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDatetime(IValueValidation iDatetime, string format, IFormatProvider provider)
        {
            try
            {
                var result = string.Empty;

                if (iDatetime != null && iDatetime.HasValue)
                {
                    var date = (DateTime)iDatetime.Value;

                    if (date != null)
                    {
                        result = date.ToString(format, provider);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDateInterval(IValueValidation iStartDatetime, IValueValidation iEndDatetime)
        {
            try
            {
                var sb = new System.Text.StringBuilder();

                if (iStartDatetime != null && iStartDatetime.HasValue)
                {
                    var date = (DateTime)iStartDatetime.Value;

                    if (date != null)
                    {
                        var factFormat = ComponentFactory.Instance.CreateFormat();

                        sb.Append(date.ToString(factFormat.Date, Culture));
                    }
                }

                if (iEndDatetime != null && iEndDatetime.HasValue)
                {
                    var date = (DateTime)iEndDatetime.Value;

                    if (date != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" - ");
                        }

                        var factFormat = ComponentFactory.Instance.CreateFormat();

                        sb.Append(date.ToString(factFormat.Date, Culture));
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDateInterval(IValueValidation iStartDatetime, IValueValidation iEndDatetime, string format)
        {
            try
            {
                var sb = new System.Text.StringBuilder();

                if (iStartDatetime != null && iStartDatetime.HasValue)
                {
                    var date = (DateTime)iStartDatetime.Value;

                    if (date != null)
                    {
                        sb.Append(date.ToString(format, Culture));
                    }
                }

                if (iEndDatetime != null && iEndDatetime.HasValue)
                {
                    var date = (DateTime)iEndDatetime.Value;

                    if (date != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" - ");
                        }

                        sb.Append(date.ToString(format, Culture));
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDateInterval(IValueValidation iStartDatetime, IValueValidation iEndDatetime, string format, IFormatProvider provider)
        {
            try
            {
                var sb = new System.Text.StringBuilder();

                if (iStartDatetime != null && iStartDatetime.HasValue)
                {
                    var date = (DateTime)iStartDatetime.Value;

                    if (date != null)
                    {
                        sb.Append(date.ToString(format, provider));
                    }
                }

                if (iEndDatetime != null && iEndDatetime.HasValue)
                {
                    var date = (DateTime)iEndDatetime.Value;

                    if (date != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" - ");
                        }

                        sb.Append(date.ToString(format, provider));
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetHashedPass(string password, string passwordFormat)
        {
            try
            {
                var encodePass = string.Empty;

                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordFormat))
                {
                    throw new Exception("Password or password format is invalid.");
                }
                else
                {
                    //Using [FormsAuthentication.HashPasswordForStoringInConfigFile] 
                    //method to hash the password .
                    //First parameter : the password to hash 
                    //Second parameter : password format(algorithms) ; either are "sha1" or "md5"
                    encodePass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, passwordFormat);
                }

                return encodePass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddSeparatorInArray<T>(T[] arrValue, object separator)
        {
            try
            {
                var sb = new System.Text.StringBuilder();

                var iCount = 0;

                foreach (var item in arrValue)
                {
                    sb.Append(item);
                    iCount++;

                    if (arrValue.Length > iCount)
                    {
                        sb.Append(separator);
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Use for upload file
        public string GetDefineFileName(string fileName, string name)
        {
            try
            {
                string newFileName = string.Empty;
                string[] tmpName = fileName.Split('.');

                if (tmpName.Length > 0)
                {
                    var dateTime = DateTime.Now.ToString().Split(' ');
                    var sb = new System.Text.StringBuilder();

                    sb.Append(name);
                    sb.AppendFormat("_{0}", dateTime[0].Replace("/", ""));
                    sb.AppendFormat("_t{0}", dateTime[1].Replace(":", ""));

                    if (tmpName.Length > 1)
                    {
                        sb.AppendFormat(".{0}", tmpName[1]);
                    }

                    newFileName = sb.ToString();
                }

                return newFileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveFileToServer(string path, byte[] bytes)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && bytes != null && bytes.Length > 0)
                {
                    System.IO.File.WriteAllBytes(path, bytes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFileInServer(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    var file = new System.IO.FileInfo(filePath);

                    if (file.Exists)
                    {
                        System.IO.File.Delete(filePath);
                    }
                    //else
                    //{
                    //    throw new Exception("File path not found.");
                    //}
                }
                //else
                //{
                //    throw new Exception("File path empty.");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAllFileInDirectory(string directoryPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(directoryPath))
                {
                    var directory = new System.IO.DirectoryInfo(directoryPath);

                    if (directory.Exists)
                    {
                        var fileList = directory.GetFiles();

                        if (fileList != null && fileList.Count() > 0)
                        {
                            foreach (var item in fileList)
                            {
                                item.Delete();
                            }
                        }
                    }
                    //else
                    //{
                    //    throw new Exception("Directory path not found.");
                    //}
                }
                //else
                //{
                //    throw new Exception("Directory path empty.");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CopyFileInServer(string sourceFilePath, string destFilePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(sourceFilePath))
                {
                    var sourceFile = new System.IO.FileInfo(sourceFilePath);

                    if (sourceFile.Exists)
                    {
                        if (!string.IsNullOrEmpty(destFilePath))
                        {
                            var destFile = new System.IO.FileInfo(destFilePath);

                            if (!destFile.Exists)
                            {
                                System.IO.File.Copy(sourceFilePath, destFilePath);
                            }
                        }
                        //else
                        //{
                        //    throw new Exception("Destination file empty.");
                        //}
                    }
                    //else
                    //{
                    //    throw new Exception("Source file not found.");
                    //}
                }
                //else
                //{
                //    throw new Exception("Source file empty.");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BackUpFileInServer(string sourceFilePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(sourceFilePath))
                {
                    var sourceFile = new System.IO.FileInfo(sourceFilePath);

                    if (sourceFile.Exists)
                    {
                        System.IO.File.Move(sourceFilePath, string.Format("{0}.bak", sourceFilePath));
                    }
                    //else
                    //{
                    //    throw new Exception("Source file not found.");
                    //}
                }
                //else
                //{
                //    throw new Exception("Source file empty.");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion    

        public void SendEmail(string emailTo, string emailSubject, string emailBody, string emailUser, string emailPassword)
        {
            try
            {
                var message = new System.Net.Mail.MailMessage();

                message.From = new System.Net.Mail.MailAddress(emailUser);
                message.To.Add(emailTo);
                message.Subject = emailSubject;
                message.Body = emailBody;
                message.IsBodyHtml = true;

                var smtp = new System.Net.Mail.SmtpClient();
            
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(emailUser, emailPassword);
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}