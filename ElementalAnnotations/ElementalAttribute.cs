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

// ReSharper disable CheckNamespace
#if ELEMENTAL_ANNOTATIONS_DEFAULT_NAMESPACE
namespace Elemental.Annotations
#else
namespace $rootnamespace$.Annotations
#endif
// ReSharper restore CheckNamespace
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
        private static IReadOnlyDictionary<Type, string> _elements;

        private static IReadOnlyDictionary<Type, string> Elements
        {
            get
            {
                return _elements ?? (_elements = typeof(CodeElement).GetTypeInfo().Assembly.DefinedTypes
                    .Where(x => x.IsSubclassOf(typeof(ElementalAttribute)))
                    .ToDictionary(x => x.AsType(), x => (string) x.GetDeclaredField("Name").GetValue(null))
                );
            }
        }

        public static int Count
        {
            get
            {
                return Elements.Count;
            }
        }

        public static IEnumerable<Type> Types
        {
            get
            {
                return Elements.Keys;
            }
        }

        public static IEnumerable<string> Names
        {
            get
            {
                return Elements.Values;
            }
        }

        public static ILookup<string, string> GetElements(MemberInfo member, bool inherit = true)
        {
            return member.GetCustomAttributes(typeof(ElementalAttribute), inherit)
                .Cast<ElementalAttribute>()
                .MakeLookup();
        }

        public static ILookup<string, string> GetElements(ParameterInfo parameter, bool inherit = true)
        {
            return parameter.GetCustomAttributes(typeof(ElementalAttribute), inherit)
                .Cast<ElementalAttribute>()
                .MakeLookup();
        }

        public static ILookup<string, string> GetElements(Module module)
        {
            return module.GetCustomAttributes(typeof(ElementalAttribute))
                .Cast<ElementalAttribute>()
                .MakeLookup();
        }

        public static ILookup<string, string> GetElements(Assembly assembly)
        {
            return assembly.GetCustomAttributes(typeof(ElementalAttribute))
                .Cast<ElementalAttribute>()
                .MakeLookup();
        }

        private static ILookup<string, string> MakeLookup(this IEnumerable<ElementalAttribute> attributes)
        {
            return attributes.ToLookup(x => Elements[x.GetType()], x => x.Description);
        }
    }
}
