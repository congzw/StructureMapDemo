﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Demos.Common._Mock
{
    public abstract class BaseMockObject : IDisposable
    {
        public bool WasDisposed { get; set; }

        protected BaseMockObject()
        {
            var type = this.GetType();
            var message = string.Format("<< create: {0} {1}", type.Name, this.GetHashCode());
            LogMessage(message);
        }

        public void Dispose()
        {
            // clean up
            var type = this.GetType();
            var message = string.Format("             dispose {0}: {1} >> ", type.Name, this.GetHashCode());
            LogMessage(message);
            WasDisposed = true;
        }

        public override string ToString()
        {
            return this.ToDebugInfo();
        }

        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(this.GetType(), message);
        }

        private static IList<string> _excludedNames = new List<string>();
        public static IList<string> ExcludedNames
        {
            get { return _excludedNames; }
            set { _excludedNames = value; }
        }
    }

    public static class ObjectDebugExtensions
    {
        public static string ToDebugInfo(this object value, Type objectType = null, int appendDeep = 0, string propName = null)
        {
            if (value == null)
            {
                return string.Format("{0}{2}<< {1} : NULL >>", Tabs(appendDeep), objectType == null ? string.Empty : objectType.Name, string.IsNullOrWhiteSpace(propName) ? "" : "["+propName+": ");
            }
            
            var t = objectType ?? value.GetType();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{3}<< {1}: {2}", Tabs(appendDeep), t.GetFriendlyName(), value.GetHashCode(), string.IsNullOrWhiteSpace(propName) ? "" : "[" + propName + ": ");

            //int append = 0;
            appendDeep++;
            var propertyInfos = t.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var propType = propertyInfo.PropertyType;
                var isSimpleType = IsSimpleType(propType);
                if (isSimpleType && propType.Name != "Tenant")
                {
                    continue;
                }

                if (BaseMockObject.ExcludedNames.Any(x => x.Equals(propType.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                sb.AppendLine();
                object propValue = propertyInfo.GetValue(value, null);
                sb.AppendFormat("{0}{1}]", Tabs(1), propValue.ToDebugInfo(objectType, appendDeep, propertyInfo.Name));
            }
            var result = sb.ToString();
            return result;
        }

        private static bool IsSimpleType(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimpleType(typeInfo.GetGenericArguments()[0]);
            }
            return typeInfo.IsPrimitive
                   || typeInfo.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal)
                //|| type == typeof(Guid)
                //|| type == typeof(DateTime)
                   || type.IsSubclassOf(typeof(ValueType)); //Guid, Datetime, etc...
        }

        private static string Tabs(int n)
        {
            if (n <= 0)
            {
                return string.Empty;
            }
            return new String('\t', n);
        }
    }
    
    public class NestedClass : BaseMockObject
    {
        public NestedClass Nested { get; set; }
        
        public static NestedClass Create(int deep)
        {
            var parent = new NestedClass();
            AppendChild(parent, deep);
            return parent;
        }

        public static void AppendChild(NestedClass parent, int deep)
        {
            var child = new NestedClass();
            parent.Nested = child;
            if (deep > 0)
            {
                AppendChild(child, --deep);
            }
        }
    }
}
