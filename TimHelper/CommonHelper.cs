using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TimHelper
{
    public class CommonHelper
    {
        public static string RandomColor()
        {
            //Random rnd = new Random();
            //Color color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //return color.ToHex();
            return null;
        }
        public static string Base64Encode(string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public static bool IsValidPhoneNumber(string phoneNumber, string langCode = "vi")
        {
            try
            {
                Regex regex;

                if (langCode == "vi")
                {
                    regex = new Regex(@"^[+]\d{11}$"); // +84347726172
                    if (regex.IsMatch(phoneNumber))
                    {
                        return true;
                    }
                    regex = new Regex(@"^\d{10}$"); // 0347726171
                    if (regex.IsMatch(phoneNumber))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool UrlValidation(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }
        public static void Screenshot(string path)
        {
            //path = path + "\\" + DateTime.Now.ToString("ddMMyyyy") + "\\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);

            //int screenLeft = SystemInformation.VirtualScreen.Left;
            //int screenTop = SystemInformation.VirtualScreen.Top;
            //int screenWidth = SystemInformation.VirtualScreen.Width;
            //int screenHeight = SystemInformation.VirtualScreen.Height;

            //// Create a bitmap of the appropriate size to receive the screenshot.
            //using (Bitmap bitmap = new Bitmap(screenWidth, screenHeight))
            //{
            //    // Draw the screenshot into our bitmap.
            //    using (Graphics g = Graphics.FromImage(bitmap))
            //    {
            //        g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap.Size);
            //    }

            //    var uniqueFileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".png";
            //    try
            //    {
            //        bitmap.Save(uniqueFileName, ImageFormat.Png);
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
        }
        public static void SetStartup(bool state)
        {
            //RegistryKey cu = Registry.CurrentUser.OpenSubKey
            //    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //RegistryKey lm = Registry.LocalMachine.OpenSubKey
            //    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            //if (state)
            //{
            //    //cu.SetValue(BaseConstant.EXE, Application.ExecutablePath);
            //    lm.SetValue(BaseConstant.EXE, Application.ExecutablePath);
            //}
            //else
            //{
            //    //cu.DeleteValue(BaseConstant.EXE, false);
            //    lm.DeleteValue(BaseConstant.EXE, false);
            //}

        }
    }
}
