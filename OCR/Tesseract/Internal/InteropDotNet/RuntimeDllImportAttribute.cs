//  Copyright (c) 2014 Andrey Akinshin
//  Project URL: https://github.com/AndreyAkinshin/InteropDotNet
//  Distributed under the MIT License: http://opensource.org/licenses/MIT

using System;
using System.Runtime.InteropServices;

namespace InteropDotNet
{
    [ComVisible(true)]
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal sealed class RuntimeDllImportAttribute : Attribute
    {
        public bool BestFitMapping;

        public CallingConvention CallingConvention;

        public CharSet CharSet;
        public string EntryPoint;

        public bool SetLastError;

        public bool ThrowOnUnmappableChar;

        public RuntimeDllImportAttribute(string libraryFileName)
        {
            LibraryFileName = libraryFileName;
        }

        public string LibraryFileName { get; private set; }
    }
}