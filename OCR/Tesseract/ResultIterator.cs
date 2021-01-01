using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Interop;

namespace Tesseract
{
    public sealed class ResultIterator : PageIterator
    {
        private readonly Dictionary<int, FontInfo> _fontInfoCache = new Dictionary<int, FontInfo>();

        internal ResultIterator(Page page, IntPtr handle)
            : base(page, handle)
        {
        }

        public float GetConfidence(PageIteratorLevel level)
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero)
                return 0f;

            return TessApi.Native.ResultIteratorGetConfidence(handle, level);
        }

        public string GetText(PageIteratorLevel level)
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return string.Empty;

            return TessApi.ResultIteratorGetUTF8Text(handle, level);
        }

        public FontAttributes GetWordFontAttributes()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return null;

            bool isBold, isItalic, isUnderlined, isMonospace, isSerif, isSmallCaps;
            int pointSize, fontId;

            // per docs (ltrresultiterator.h:104 as of 4897796 in github:tesseract-ocr/tesseract)
            // this return value points to an internal table and should not be deleted.
            var nameHandle =
                TessApi.Native.ResultIteratorWordFontAttributes(
                    handle,
                    out isBold, out isItalic, out isUnderlined,
                    out isMonospace, out isSerif, out isSmallCaps,
                    out pointSize, out fontId);

            // This can happen in certain error conditions
            if (nameHandle == IntPtr.Zero) return null;

            FontInfo fontInfo;
            if (!_fontInfoCache.TryGetValue(fontId, out fontInfo))
            {
                var fontName = MarshalHelper.PtrToString(nameHandle, Encoding.UTF8);
                fontInfo = new FontInfo(fontName, fontId, isItalic, isBold, isMonospace, isSerif);
                _fontInfoCache.Add(fontId, fontInfo);
            }

            return new FontAttributes(fontInfo, isUnderlined, isSmallCaps, pointSize);
        }

        public string GetWordRecognitionLanguage()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return null;

            return TessApi.ResultIteratorWordRecognitionLanguage(handle);
        }

        public bool GetWordIsFromDictionary()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return false;

            return TessApi.Native.ResultIteratorWordIsFromDictionary(handle);
        }

        public bool GetWordIsNumeric()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return false;

            return TessApi.Native.ResultIteratorWordIsNumeric(handle);
        }

        public bool GetSymbolIsSuperscript()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return false;

            return TessApi.Native.ResultIteratorSymbolIsSuperscript(handle);
        }

        public bool GetSymbolIsSubscript()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return false;

            return TessApi.Native.ResultIteratorSymbolIsSubscript(handle);
        }

        public bool GetSymbolIsDropcap()
        {
            VerifyNotDisposed();
            if (handle.Handle == IntPtr.Zero) return false;

            return TessApi.Native.ResultIteratorSymbolIsDropcap(handle);
        }

        /// <summary>
        ///     Gets an instance of a choice iterator using the current symbol of interest. The ChoiceIterator allows a one-shot
        ///     iteration over the
        ///     choices for this symbol and after that is is useless.
        /// </summary>
        /// <returns>an instance of a Choice Iterator</returns>
        public ChoiceIterator GetChoiceIterator()
        {
            var choiceIteratorHandle = TessApi.Native.ResultIteratorGetChoiceIterator(handle);
            if (choiceIteratorHandle == IntPtr.Zero)
                return null;
            return new ChoiceIterator(choiceIteratorHandle);
        }
    }
}