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

    public static class CodeElements
    {
        public static IEnumerable<Type> GetElementTypesInAssembly(Assembly assembly)
        {
            return assembly.ExportedTypes
                .Where(x => x.GetTypeInfo().IsSubclassOf(typeof(ElementalAttribute)));
        }

        public static ILookup<Type, string> GetElements(MemberInfo member, bool inherit = true)
        {
            return member.GetCustomAttributes(typeof(ElementalAttribute), inherit)
                .ToLookup(x => x.GetType(), x => ((ElementalAttribute) x).Description);
        }
    }
}
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
