using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ryan.Framework.DotNetFx40.ORM.Attributes
{
    public static  class CustomAttributeHelper
    {
        /// <summary>
        /// Cache Data
        /// </summary>
        private static readonly Dictionary<string, string> Cache = new Dictionary<string, string>();

        /// <summary>
        /// 获取CustomAttribute Value
        /// </summary>
        /// <typeparam name="T">Attribute的子类型</typeparam>
        /// <param name="sourceType">头部标有CustomAttribute类的类型</param>
        /// <param name="attributeValueAction">取Attribute具体哪个属性值的匿名函数</param>
        /// <returns>返回Attribute的值，没有则返回null</returns>
        public static string GetCustomAttributeValue<T>(this Type sourceType, Func<T, string> attributeValueAction) where T : Attribute
        {
            return GetAttributeValue(sourceType, attributeValueAction, null);
        }

        /// <summary>
        /// 获取CustomAttribute Value
        /// </summary>
        /// <typeparam name="T">Attribute的子类型</typeparam>
        /// <param name="sourceType">头部标有CustomAttribute类的类型</param>
        /// <param name="attributeValueAction">取Attribute具体哪个属性值的匿名函数</param>
        /// <param name="name">field name或property name</param>
        /// <returns>返回Attribute的值，没有则返回null</returns>
        public static string GetCustomAttributeValue<T>(this Type sourceType, Func<T, string> attributeValueAction,
            string name) where T : Attribute
        {
            return GetAttributeValue(sourceType, attributeValueAction, name);
        }

        private static string GetAttributeValue<T>(Type sourceType, Func<T, string> attributeValueAction,
            string name) where T : Attribute
        {
            var key = BuildKey(sourceType, name);
            if (!Cache.ContainsKey(key))
            {
                CacheAttributeValue(sourceType, attributeValueAction, name);
            }

            return Cache[key];
        }

        /// <summary>
        /// 缓存Attribute Value
        /// </summary>
        private static void CacheAttributeValue<T>(Type type,
            Func<T, string> attributeValueAction, string name)
        {
            var key = BuildKey(type, name);

            var value = GetValue(type, attributeValueAction, name);

            lock (key + "_attributeValueLockKey")
            {
                if (!Cache.ContainsKey(key))
                {
                    Cache[key] = value;
                }
            }
        }

        private static string GetValue<T>(Type type,
            Func<T, string> attributeValueAction, string name)
        {
            object attribute = null;
            if (string.IsNullOrEmpty(name))
            {
                attribute =
                    type.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            }
            else
            {
                var propertyInfo = type.GetProperty(name);
                if (propertyInfo != null)
                {
                    attribute =
                        propertyInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                }

                var fieldInfo = type.GetField(name);
                if (fieldInfo != null)
                {
                    attribute = fieldInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                }
            }

            return attribute == null ? null : attributeValueAction((T)attribute);
        }

        /// <summary>
        /// 缓存Collection Name Key
        /// </summary>
        private static string BuildKey(Type type, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return type.FullName;
            }

            return type.FullName + "." + name;
        }

        public static string GetTableName<T>()
        {
            string tableName = typeof(T).Name;
            TableAttribute attr = Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute)) as TableAttribute;
            if (attr != null)
            {
                tableName = attr.TableName;
            }
            return tableName; 
        }

        /// <summary>
        /// 得到标识列列表
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="UnIndentity">非标识列</param>
        /// <returns></returns>
        public static string GetIdentityList<T>(bool UnIndentity)
        {
            string ret = "";
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                AutoIncrementAttribute attAutoIncrement = Attribute.GetCustomAttribute(propertyInfo, typeof(AutoIncrementAttribute)) as AutoIncrementAttribute;
                TimeSpanAttribute attTimeSpan = Attribute.GetCustomAttribute(propertyInfo, typeof(TimeSpanAttribute)) as TimeSpanAttribute;
                if (UnIndentity)
                {
                    if (attAutoIncrement == null && attTimeSpan == null)
                    {
                        ret += propertyInfo.Name + ", ";
                    }
                }
                else
                {
                    if (attAutoIncrement != null || attTimeSpan != null)
                    {
                        ret += propertyInfo.Name + ", ";
                    }
                }
            }

            return ret.Length > 0 ? ret.Remove(ret.Length - 2, 2) : "";
        }


        /// <summary>
        /// 得到特定属性列表
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="attributes">特定属性</param>
        /// <param name="UnAttribute">非特定属性列</param>
        /// <returns></returns>
        public static string GetAttributeList<T>(Attribute[]  attributes, bool UnAttribute)
        {
            string ret = "";
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object[] atts = propertyInfo.GetCustomAttributes(true);
                if (atts.Length == 0 && UnAttribute)
                {
                    ret += propertyInfo.Name + ", ";
                }
                else if(atts.Length == 0 && UnAttribute == false)
                {
                    //为空
                }
                else if(atts.Length > 0 && UnAttribute == false)
                {
                    foreach(Attribute att in atts)
                    {
                        if(attributes.Contains(att))
                        {
                            ret += propertyInfo.Name + ", ";
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Attribute att in atts)
                    {
                        if (attributes.Contains(att))
                        {
                            break;
                        }
                        ret += propertyInfo.Name + ", ";

                    }
                }
            }

            return ret.Length > 0 ? ret.Remove(ret.Length - 2, 2) : "";
        }
    }
}