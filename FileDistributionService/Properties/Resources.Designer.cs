﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsTec.FileDistributionService.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UsTec.FileDistributionService.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   ファイルを配布しました。{0}, {1}, {2} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string FileCopied_Info {
            get {
                return ResourceManager.GetString("FileCopied_Info", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ファイルを配布します。{0}, {1}, {2} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string FileCopying_Info {
            get {
                return ResourceManager.GetString("FileCopying_Info", resourceCulture);
            }
        }
        
        /// <summary>
        ///   配布元ファイルを削除しました。 {0} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SourceFileDeleted_Info {
            get {
                return ResourceManager.GetString("SourceFileDeleted_Info", resourceCulture);
            }
        }
        
        /// <summary>
        ///   配布元ファイルを削除します。 {0} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SourceFileDeleting_Info {
            get {
                return ResourceManager.GetString("SourceFileDeleting_Info", resourceCulture);
            }
        }
    }
}
