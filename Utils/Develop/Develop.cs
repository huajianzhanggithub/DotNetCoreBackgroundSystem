using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Data.Models;

namespace Utils.Develop
{
    public class Develop
    {
        /// <summary>
        /// 解决方案所在目录,即根目录
        /// </summary>
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
        /// <summary>
        /// 通过 Assembly加载Data的程序集，然后选择出符合我们要求的实体类。
        /// </summary>
        /// <returns></returns>
        public static Type[] LoadEntities()
        {
            var assembly = Assembly.Load("Data");
            var allTypes = assembly.GetTypes();
            var ofNamespace = allTypes.Where(t => t.Namespace == "Data.Models" || t.Namespace.StartsWith("Data.Models."));
            var subTypes = allTypes.Where(t => t.BaseType.Name == "BaseEntity`1");
            return ofNamespace.Union(subTypes).ToArray();
        }
        /// <summary>
        /// 生成Repository接口的方法
        /// </summary>
        /// <param name="type"></param>
        public static void CreateRespositoryInterface(Type type)
        {
            var targetNamespace = type.Namespace.Replace("Data.Models", "");
            if (targetNamespace.StartsWith("."))
            {
                targetNamespace = targetNamespace.Remove(0);
            }
            var targetDir = Path.Combine(new[] { CurrentDirect, "Domain", "Repository" }.Concat(targetNamespace.Split('.')).ToArray());
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            var baseName = type.Name.Replace("Entity", "");
            if (!string.IsNullOrEmpty(targetNamespace))
            {
                targetNamespace = $".{targetNamespace}";
            }
            var file = $"using {type.Namespace};\r\n"
                + $"using Domain.Infrastructure;\r\n"
                + $"namespace Domain.Repository{targetNamespace}\r\n"
                + "{\r\n"
                + $"\tpublic interface I{baseName}ModifyRepository : IModifyRepository<{type.Name}>\r\n"
                + "\t{\r\n\t}\r\n"
                + $"\tpublic interface I{baseName}SearchRepository : ISearchRepository<{type.Name}>\r\n"
                + "\t{\r\n\t}\r\n}";
            File.WriteAllText(Path.Combine(targetDir, $"I{baseName}Repository.cs"), file);
        }
        public static void CreateRepositoryImplement(Type type)
        {
            var targetNamespace = type.Namespace.Replace("Data.Models", "");
            if (targetNamespace.StartsWith("."))
            {
                targetNamespace = targetNamespace.Remove(0);
            }
            var targetDir = Path.Combine(new[] { CurrentDirect, "Domain.Implements", "Repository" }.Concat(targetNamespace.Split('.')).ToArray());
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            var baseName = type.Name.Replace("Entity", "");
            if (!string.IsNullOrEmpty(targetNamespace))
            {
                targetNamespace = $".{targetNamespace}";
            }
            var file = $"using {type.Namespace};"
                + $"\r\nusing Domain.Implements.Infrastructure;"
                + $"\r\nusing Domain.Repository{targetNamespace};"
                + $"\r\nusing Microsoft.EntityFrameworkCore;"
                + $"namespace Domain.Implements.Repository{targetNamespace}\r\n"
                + "{"
                + $"\r\n\tpublic class {baseName}Repository : BaseRepository<{type.Name}>, I{baseName}ModifyRepository,I{baseName}SearchRepository "
                + "\r\n\t{"
                + $"\r\n\tpublic {baseName}Repository(DbContext context) : base(context)"
                + "\r\n\t\t{"
                + "\r\n\t\t}\r\n"
                + "\t}\r\n}";
            File.WriteAllText(Path.Combine(targetDir, $"{baseName}Repository.cs"), file);
        }
        public static void CreateEntityTypeConfig(Type type)
        {
            var targetNamespace = type.Namespace.Replace("Data.Models", "");
            if (targetNamespace.StartsWith("."))
            {
                targetNamespace = targetNamespace.Remove(0);
            }
            var targetDir = Path.Combine(new[] { CurrentDirect, "Domain.Implements", "EntityConfigures" }.Concat(targetNamespace.Split('.')).ToArray());
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            var baseName = type.Name.Replace("Entity", "");
            if (!string.IsNullOrEmpty(targetNamespace))
            {
                targetNamespace = $".{targetNamespace}";
            }
            var file = $"using {type.Namespace};"
                + $"\r\nusing Microsoft.EntityFrameworkCore;"
                + $"\r\nusing Microsoft.EntityFrameworkCore.Metadata.Builders;\r\n"
                + $"\r\nnamespace Domain.Implements.EntityConfigures{targetNamespace}"
                + "\r\n{"
                + $"\r\n\tpublic class {baseName}Config : IEntityTypeConfiguration<{type.Name}>"
                + "\r\n\t{" +
                $"\r\n\tpublic void Configure(EntityTypeBuilder<{type.Name}> builder)" +
                "\r\n\t\t{" +
                $"\r\n\t\t\tbuilder.ToTable(\"{baseName}\");" +
                $"\r\n\t\t\tbuilder.HasKey(p => p.Id);" +
                "\r\n\t\t}\r\n\t}\r\n}";
            File.WriteAllText(Path.Combine(targetDir, $"{baseName}Config.cs"), file);
        }
    }
}
