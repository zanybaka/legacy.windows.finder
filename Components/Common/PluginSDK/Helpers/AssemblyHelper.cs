using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Samples.Finder.Components.Common.PluginSDK.Helpers
{
    public static class AssemblyHelper
    {
        private static bool FilterClassDerivatives(Type type, object baseType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return type.IsSubclassOf((Type) baseType);
        }

        private static bool FilterInterfaceDerivatives(Type type, object baseType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (baseType == null)
            {
                throw new ArgumentNullException("baseType");
            }
            return type.GetInterface(baseType.ToString()) != null;
        }

        public static List<Type> GetClassInheritances<TType>(Assembly assembly)
        {
            var list = new List<Type>();
            Module[] modules = assembly.GetModules(false);
            foreach (Module module in modules)
            {
                Type[] types = module.FindTypes(FilterClassDerivatives, typeof (TType));
                list.AddRange(types);
            }
            return list;
        }

        public static List<Type> GetInterfaceInheritances<TType>(Assembly assembly)
        {
            var list = new List<Type>();
            Module[] modules = assembly.GetModules(false);
            foreach (Module module in modules)
            {
                Type[] types = module.FindTypes(FilterInterfaceDerivatives, typeof (TType));
                list.AddRange(types);
            }
            return list;
        }

        public static List<Type> GetInterfaceInheritances<TInterface>(IEnumerable<string> files)
        {
            var result = new List<Type>();
            foreach (string file in files)
            {
                Assembly assembly;
                try
                {
                    assembly = Assembly.LoadFrom(file);
                }
                catch (BadImageFormatException) //non .NET lib
                {
                    throw;
                    //TODO: implement Exception Policy here (Log Action, ...)
                    //continue;
                }
                IList<Type> list = GetInterfaceInheritances<TInterface>(assembly);
                result.AddRange(list);
            }
            return result;
        }

        public static List<TInterface> LoadInterfaceInheritances<TInterface>(string directory, string pattern)
        {
            var result = new List<TInterface>();
            var directoryInfo = new DirectoryInfo(directory);
            FileInfo[] info;
            try
            {
                info = directoryInfo.GetFiles(pattern);
            }
            catch (DirectoryNotFoundException)
            {
                throw;
                //TODO: implement Exception Policy here (Log Action, ...)
                //return result;
            }
            var files = info.Select(file => file.FullName).ToList();
            foreach (Type type in GetInterfaceInheritances<TInterface>(files))
            {
                var plugin = (TInterface) Activator.CreateInstance(type);
                result.Add(plugin);
            }
            return result;
        }
    }
}