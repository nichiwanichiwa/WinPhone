﻿using PhoneApp3.Resources;

namespace PhoneApp3
{
    /// <summary>
    /// 文字列リソースにアクセスできるようにします。
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}