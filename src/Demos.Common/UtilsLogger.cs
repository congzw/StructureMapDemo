﻿using System;

namespace Demos.Common
{
    public class UtilsLogger
    {
        public static void LogMessage(params string[] messages)
        {
            foreach (var message in messages)
            {
                defaultLogAction.Invoke(message);
            }
        }
        
        public static void LogMessage(Type type, params string[] messages)
        {
            foreach (var message in messages)
            {

                defaultLogAction.Invoke(string.Format("[{0}] {1}", type.Name, message));
            }
        }
        
        public static void SetLogFunc(Action<string> action)
        {
            if (action != null)
            {
                defaultLogAction = action;
            }
        }

        private static Action<string> defaultLogAction = new Action<string>(TraceMessage);
        private static string prefix = null;
        private static void TraceMessage(string message)
        {
            if (prefix == null)
            {
                prefix = GetPrefix();
            }
            System.Diagnostics.Trace.WriteLine(prefix + message);
        }
        private static string GetPrefix()
        {
            string prefixSeed = "[Demos][UtilsLogger]";
            return prefixSeed + " => ";
        }
    }
}
