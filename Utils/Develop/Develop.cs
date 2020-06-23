using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utils.Develop
{
    class Develop
    {
        public static string CurrentDirect
        {
            get
            {
                var execute = Directory.GetCurrentDirectory();
                var parent = Directory.GetParent(execute);
                while (parent.GetFiles("*.sln", SearchOption.TopDirectoryOnly).Length == 0)
                {
                    parent = parent.Parent;
                    if (parent == null)
                    {
                        return null;
                    }
                }
                return parent.FullName;
            }
        }
        public static Type[] LoadEntities()
        {
            var assembly = Assembly.Load("Data");
            var allTypes = assembly.GetTypes();
            var ofNamespace = allTypes.Where(t => t.Namespace == "Data.Models" || t.Namespace.StartsWith("Data.Models."));
            var subTypes = allTypes.Where(t => t.BaseType.Name == "BaseEntity`1");
            return ofNamespace.Union(subTypes).ToArray();
        }

    }
}
