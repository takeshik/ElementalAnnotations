/*
 * Elemental Annotations <https://github.com/takeshik/ElementalAnnotations>
 * Copyright © 2015 Takeshi KIRIYA (aka takeshik) <takeshik@tksk.io>
 * Licensed under the zlib License; for details, see the website.
 */

using System;
using System.Diagnostics;

namespace Elemental.Annotations
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    [Conditional("DEBUG")]
    public class LightAttribute
        : ElementalAttribute
    {
        public const string Name = "Light";

        public LightAttribute(string description = null)
            : base(description)
        {
        }
    }

    partial class CodeElement
    {
        public const string Light = LightAttribute.Name;
    }
}
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
