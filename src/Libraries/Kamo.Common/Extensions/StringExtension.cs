using Kamo.Common.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace Kamo.Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 将字符串转成二进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Code(this string s)
        {
            byte[] data = Encoding.Unicode.GetBytes(s);
            StringBuilder result = new StringBuilder(data.Length * 8);

            foreach (byte b in data)
            {
                result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return result.ToString();
        }

        public static T ToObject<T>(this string str) where T : class
        {
            if (!str.IsNullOrEmpty())
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            return default(T);
        }

        public static dynamic ToJson(this string str)
        {
            if (!str.IsNullOrEmpty())
            {
                return (dynamic)JsonConvert.DeserializeObject(str);
            }
            return null;
        }

        /// <summary>
        ///  将Json字符串解析为一个动态类型
        /// </summary>
        /// <returns></returns>
        public static dynamic ToObject(this string jsonStr, bool camelCase = true, bool indented = false)
        {
            var options = new JsonSerializerSettings();

            if (camelCase)
            {
                options.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            else
            {
                options.ContractResolver = new DefaultContractResolver();
            }

            if (indented)
            {
                options.Formatting = Formatting.Indented;
            }

            options.Converters.Insert(0, new KamoDateTimeConverter());

            return JsonConvert.DeserializeObject(jsonStr, options);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// * 将驼峰式命名的字符串转换为下划线大写方式。如果转换前的驼峰式命名的字符串为空，则返回空字符串。</br>
        /// * 例如：HelloWorld->
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string UnderScoreName(this string name)
        {
            StringBuilder result = new StringBuilder();
            if (name != null && name.Length > 0)
            {
                // 将第一个字符处理成大写
                result.Append(name.Substring(0, 1));
                // 循环处理其余字符
                for (int i = 1; i < name.Length; i++)
                {
                    string s = name.Substring(i, 1);
                    // 在大写字母前添加下划线
                    if (Char.IsUpper(s[0]))
                    {
                        result.Append("_");
                    }
                    // 其他字符直接转成大写
                    result.Append(s);
                }
            }
            return result.ToString().ToLower();
        }
    }
}