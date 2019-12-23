namespace QuickEditor.Common
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class QuickEditorRegexExtensions
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");//w 英文字母或数字的字符串,和[a-zA-Z0-9]语法一样
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        //private static Regex ValidIpAddressRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
        //private static Regex ValidHostnameRegex = new Regex(@"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$");

        /// <summary>
        /// 去除微信表情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RemoveEmoticon(this string data)
        {
            return Regex.Replace(data, @"(\\ud[0-9a-f]{3})|(\\ue[0-9a-f]{3})", "", RegexOptions.IgnoreCase);
        }

        #region 数字字符串检查

        /// <summary>
        /// int有效性
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        static public bool IsValidInt(string val)
        {
            return Regex.IsMatch(val, @"^[1-9]\d*\.?[0]*$");
        }

        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否是负数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsNegative(this string num)
        {
            return Regex.IsMatch(num, @"^-[0-9]*[1-9][0-9]*$");
        }

        #endregion 数字字符串检查

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 检测含有中文字符串的实际长度
        /// </summary>
        /// <param name="str">字符串</param>
        public static int GetCHZNLength(string inputData)
        {
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] bytes = n.GetBytes(inputData);

            int length = 0; // l 为字符串之实际长度
            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                if (bytes[i] == 63) //判断是否为汉字或全脚符号
                {
                    length++;
                }
                length++;
            }
            return length;
        }

        #endregion 中文检测

        #region 用户名 密码验证

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string stringValue)
        {
            return Encoding.Default.GetBytes(stringValue).Length;
        }

        /// <summary>
        /// 检测用户名格式是否有效 判断用户名的长度（6-20个字符）及内容（只能是汉字、字母、下划线、数字）是否合法
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsValidUserName(string userName)
        {
            int userNameLength = GetStringLength(userName);
            if (userNameLength >= 6 && userNameLength <= 20 && Regex.IsMatch(userName, @"^([\u4e00-\u9fa5A-Za-z_0-9]{0,})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 密码有效性
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^[A-Za-z_0-9]{6,16}$");
        }

        // 账号验证  以字母开头 数字与字母符号相结合的方式组成的6-15位数
        public static bool AccountVenify(this string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\d!@#$%^&*.,_+-=]{6,15}$");
        }

        //PassVenify("12345676722");//容易
        //PassVenify("qwe1234erw");//中等
        //PassVenify("qwe12345...#$%3&");//复杂
        //PassVenify("1325556");//没有符合要求的表达式
        public static string PassVenify(this string input)
        {
            //复杂 必须有数字与字母和符号混合组成的8-15位数
            string aPatter = @"^(?![a-zA-Z]{8,15}$)(?![\d{8,15}])(?![!@#$%^&*.]{8,15}$)(?![a-zA-Z\d]{8,15}$)(?![a-zA-Z!@#$%^&*.]{8,15})(?![\d!@#$%^&*.]{8,15}$)([a-zA-Z\d!@#$%^&*.]{8,15}&)";
            //中等  由数字和字母或者数字和符号或者字母和符号组成的8-15位数
            string bPatter = @"^(?![a-zA-Z]{8,15}$)(?![\d{8,15}])(?![!@#$%^&*.]{8,15}$)([a-zA-Z\d]|[a-zA-Z!@#$%^&*.]|[\d!@#$%^&*.]){8,15}$";
            //简单  由单一的数字或者字母或者符号组成的8-15位数
            string cPatter = @"^([a-zA-Z]|[\d{8,15}]|[!@#$%^&*.]){8,15}$";
            Regex a = new Regex(aPatter);
            Regex b = new Regex(bPatter);
            Regex c = new Regex(cPatter);
            if (a.IsMatch(input))
            {
                return "密码程度:复杂";
            }
            else if (b.IsMatch(input))
            {
                return "密码程度:中等";
            }
            else if (c.IsMatch(input))
            {
                return "密码程度:容易";
            }
            else
                return "密码不符合条件";
        }

        #endregion 用户名 密码验证

        /// <summary>
        /// 是否是身份证号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsIdCard(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return false; }

            if (input.Length == 15)
            {
                return Regex.IsMatch(input, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$");
            }
            else if (input.Length == 18)
            {
                return Regex.IsMatch(input, @"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$", RegexOptions.IgnoreCase);
            }
            else
            {
                return false;
            }
        }

        public static bool IsCellPhone(this string str_handset)
        {
            return Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}");
        }

        public static bool IsTelephone(this string str_telephone)
        {
            return Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        /// <summary>
        /// 是否是邮编
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPostCode(this string input)
        {
            return Regex.IsMatch(input, @"^[1-9]\d{5}(?!\d)$");
        }

        public static bool IsIP(this string input)
        {
            return Regex.IsMatch(input, @"^\d+\.\d+\.\d+\.\d+$");
        }

        public static bool IsURL(this string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-z]+://[^\s]*$");
        }

        /// <summary>
        /// 验证字符串是否是GUID
        /// </summary>
        /// <param name="guid">字符串</param>
        /// <returns></returns>
        public static bool IsGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return false;

            return Regex.IsMatch(guid, "[A-F0-9]{8}(-[A-F0-9]{4}){3}-[A-F0-9]{12}|[A-F0-9]{32}", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 是否是邮件地址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            return RegEmail.Match(inputData).Success;
        }

        /// <summary>
        /// 邮编有效性
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        public static bool IsValidZip(string zip)
        {
            Regex rx = new Regex(@"^\d{6}$", RegexOptions.None);
            Match m = rx.Match(zip);
            return m.Success;
        }

        /// <summary>
        /// 固定电话有效性
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidPhone(string phone)
        {
            Regex rx = new Regex(@"^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$", RegexOptions.None);
            Match m = rx.Match(phone);
            return m.Success;
        }

        /// <summary>
        /// 手机有效性
        /// </summary>
        /// <param name="strMobile"></param>
        /// <returns></returns>
        public static bool IsValidMobile(string mobile)
        {
            Regex rx = new Regex(@"^(13|15|17|18|19)\d{9}$", RegexOptions.None);
            Match m = rx.Match(mobile);
            return m.Success;
        }

        /// <summary>
        /// 电话有效性(固话和手机)
        /// </summary>
        /// <param name="strVla"></param>
        /// <returns></returns>
        public static bool IsValidPhoneAndMobile(string number)
        {
            Regex rx = new Regex(@"^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$|^(13|15)\d{9}$", RegexOptions.None);
            Match m = rx.Match(number);
            return m.Success;
        }

        /// <summary>
        /// Url有效性
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public bool IsValidURL(string url)
        {
            return Regex.IsMatch(url, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*[^\.\,\)\(\s]$");
        }

        /// <summary>
        /// IP有效性
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 判断是否为base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

        public static bool IsIPv4(string input)
        {
            string[] IPs = input.Split('.');

            for (int i = 0; i < IPs.Length; i++)
            {
                if (!IsMatch(@"^\d+$", IPs[i]))
                {
                    return false;
                }
                if (Convert.ToUInt16(IPs[i]) > 255)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsIPV6(string input)
        {
            string pattern = "";
            string temp = input;
            string[] strs = temp.Split(':');
            if (strs.Length > 8) { return false; }
            int count = GetStringCount(input, "::");
            if (count > 1) { return false; }
            else if (count == 0)
            {
                pattern = @"^([\da-f]{1,4}:){7}[\da-f]{1,4}$";
                return IsMatch(pattern, input);
            }
            else
            {
                pattern = @"^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$";
                return IsMatch(pattern, input);
            }
        }

        private static int GetStringCount(string input, string compare)
        {
            int index = input.IndexOf(compare);
            if (index != -1)
            {
                return 1 + GetStringCount(input.Substring(index + compare.Length), compare);
            }
            else
            {
                return 0;
            }
        }

        public static bool IsMatch(string pattern, string input)
        {
            if (input == null) return false;
            return Regex.IsMatch(input, pattern);
            //return new Regex(pattern).IsMatch(input);
        }

        public static string Replace(string pattern, string input, string replacement)
        {
            return new Regex(pattern).Replace(input, replacement);
        }

        public static string[] Split(string pattern, string input)
        {
            return new Regex(pattern).Split(input);
        }
    }
}
