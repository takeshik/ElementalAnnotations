/*
 * Elemental Annotations <https://github.com/takeshik/ElementalAnnotations>
 * Copyright © 2015 Takeshi KIRIYA (aka takeshik) <takeshik@tksk.io>
 * Licensed under the zlib License; for details, see the website.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Elemental.Annotations
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    [Conditional("DEBUG")]
    public abstract class ElementalAttribute
        : Attribute
    {
        public string Description { get; private set; }

        protected ElementalAttribute(string description = null)
        {
            this.Description = description;
        }
    }

    public static partial class CodeElement
    {
        private static readonly Lazy<IReadOnlyDictionary<Type, string>> _elements =
            new Lazy<IReadOnlyDictionary<Type, string>>(() => typeof(CodeElement).GetTypeInfo().Assembly.DefinedTypes
                .Where(x => x.IsSubclassOf(typeof(ElementalAttribute)))
                .ToDictionary(x => x.AsType(), x => (string) x.GetDeclaredField("Name").GetValue(null))
            );

        public static IEnumerable<Type> Types
        {
            get
            {
                return _elements.Value.Keys;
            }
        }

        public static IEnumerable<string> Names
        {
            get
            {
                return _elements.Value.Values;
            }
        }

        public static ILookup<string, string> GetElements(MemberInfo member, bool inherit = true)
        {
            return member.GetCustomAttributes(typeof(ElementalAttribute), inherit)
                .MakeLookup();
        }

        public static ILookup<string, string> GetElements(ParameterInfo parameter, bool inherit = true)
        {
            return parameter.GetCustomAttributes(typeof(ElementalAttribute), inherit)
                .MakeLookup();
        }

        public static ILookup<string, string> GetElements(Module module)
        {
            return module.GetCustomAttributes(typeof(ElementalAttribute))
                .MakeLookup();
        }

        public static ILookup<string, string> GetElements(Assembly assembly)
        {
            return assembly.GetCustomAttributes(typeof(ElementalAttribute))
                .MakeLookup();
        }

        private static ILookup<string, string> MakeLookup(this IEnumerable<Attribute> attributes)
        {
            return attributes.ToLookup(x => _elements.Value[x.GetType()], x => ((ElementalAttribute) x).Description);
        }
    }
}
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
