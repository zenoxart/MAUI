; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [319 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [632 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 70
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 69
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 110
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 236
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 270
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 50
	i32 38948123, ; 6: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 278
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 194
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 82
	i32 42244203, ; 9: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 287
	i32 42639949, ; 10: System.Threading.Thread => 0x28aa24d => 147
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 32
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 311
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 126
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 193
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 104
	i32 83839681, ; 16: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 295
	i32 101534019, ; 17: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 254
	i32 117431740, ; 18: System.Runtime.InteropServices => 0x6ffddbc => 109
	i32 120558881, ; 19: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 254
	i32 122350210, ; 20: System.Threading.Channels.dll => 0x74aea82 => 141
	i32 134690465, ; 21: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 274
	i32 136584136, ; 22: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 310
	i32 140062828, ; 23: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 303
	i32 142721839, ; 24: System.Net.WebHeaderCollection => 0x881c32f => 79
	i32 149972175, ; 25: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 126
	i32 159306688, ; 26: System.ComponentModel.Annotations => 0x97ed3c0 => 15
	i32 165246403, ; 27: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 210
	i32 176265551, ; 28: System.ServiceProcess => 0xa81994f => 134
	i32 179603148, ; 29: Maui.DatenObjekte => 0xab486cc => 312
	i32 182336117, ; 30: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 256
	i32 184328833, ; 31: System.ValueTuple.dll => 0xafca281 => 153
	i32 186038784, ; 32: Maui.Kern.resources => 0xb16ba00 => 0
	i32 205061960, ; 33: System.ComponentModel => 0xc38ff48 => 20
	i32 209399409, ; 34: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 208
	i32 220171995, ; 35: System.Diagnostics.Debug => 0xd1f8edb => 28
	i32 230216969, ; 36: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 230
	i32 230752869, ; 37: Microsoft.CSharp.dll => 0xdc10265 => 3
	i32 231409092, ; 38: System.Linq.Parallel => 0xdcb05c4 => 61
	i32 231814094, ; 39: System.Globalization => 0xdd133ce => 44
	i32 246610117, ; 40: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 93
	i32 261689757, ; 41: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 213
	i32 276479776, ; 42: System.Threading.Timer.dll => 0x107abf20 => 149
	i32 278686392, ; 43: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 232
	i32 280482487, ; 44: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 229
	i32 291076382, ; 45: System.IO.Pipes.AccessControl.dll => 0x1159791e => 56
	i32 298918909, ; 46: System.Net.Ping.dll => 0x11d123fd => 71
	i32 317674968, ; 47: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 308
	i32 318968648, ; 48: Xamarin.AndroidX.Activity.dll => 0x13031348 => 199
	i32 321597661, ; 49: System.Numerics => 0x132b30dd => 85
	i32 321963286, ; 50: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 286
	i32 342366114, ; 51: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 231
	i32 360082299, ; 52: System.ServiceModel.Web => 0x15766b7b => 133
	i32 367780167, ; 53: System.IO.Pipes => 0x15ebe147 => 57
	i32 374914964, ; 54: System.Transactions.Local => 0x1658bf94 => 151
	i32 375677976, ; 55: System.Net.ServicePoint.dll => 0x16646418 => 76
	i32 379916513, ; 56: System.Threading.Thread.dll => 0x16a510e1 => 147
	i32 385762202, ; 57: System.Memory.dll => 0x16fe439a => 64
	i32 392610295, ; 58: System.Threading.ThreadPool.dll => 0x1766c1f7 => 148
	i32 395744057, ; 59: _Microsoft.Android.Resource.Designer => 0x17969339 => 315
	i32 403441872, ; 60: WindowsBase => 0x180c08d0 => 167
	i32 409257351, ; 61: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 306
	i32 441335492, ; 62: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 214
	i32 442565967, ; 63: System.Collections => 0x1a61054f => 14
	i32 450948140, ; 64: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 227
	i32 451504562, ; 65: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 127
	i32 456227837, ; 66: System.Web.HttpUtility.dll => 0x1b317bfd => 154
	i32 459347974, ; 67: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 115
	i32 465846621, ; 68: mscorlib => 0x1bc4415d => 168
	i32 469710990, ; 69: System.dll => 0x1bff388e => 166
	i32 476646585, ; 70: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 229
	i32 486930444, ; 71: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 242
	i32 489220957, ; 72: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 284
	i32 498788369, ; 73: System.ObjectModel => 0x1dbae811 => 86
	i32 513247710, ; 74: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 187
	i32 526420162, ; 75: System.Transactions.dll => 0x1f6088c2 => 152
	i32 527452488, ; 76: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 274
	i32 530272170, ; 77: System.Linq.Queryable => 0x1f9b4faa => 62
	i32 538707440, ; 78: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 305
	i32 539058512, ; 79: Microsoft.Extensions.Logging => 0x20216150 => 183
	i32 540030774, ; 80: System.IO.FileSystem.dll => 0x20303736 => 53
	i32 545304856, ; 81: System.Runtime.Extensions => 0x2080b118 => 105
	i32 546455878, ; 82: System.Runtime.Serialization.Xml => 0x20924146 => 116
	i32 549171840, ; 83: System.Globalization.Calendars => 0x20bbb280 => 42
	i32 557405415, ; 84: Jsr305Binding => 0x213954e7 => 267
	i32 569601784, ; 85: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 265
	i32 577335427, ; 86: System.Security.Cryptography.Cng => 0x22697083 => 122
	i32 581878650, ; 87: Maui.Kern.resources.dll => 0x22aec37a => 0
	i32 597488923, ; 88: CommunityToolkit.Maui => 0x239cf51b => 175
	i32 601371474, ; 89: System.IO.IsolatedStorage.dll => 0x23d83352 => 54
	i32 605376203, ; 90: System.IO.Compression.FileSystem => 0x24154ecb => 46
	i32 613668793, ; 91: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 121
	i32 627609679, ; 92: Xamarin.AndroidX.CustomView => 0x2568904f => 219
	i32 627931235, ; 93: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 297
	i32 639843206, ; 94: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 225
	i32 643868501, ; 95: System.Net => 0x2660a755 => 83
	i32 662205335, ; 96: System.Text.Encodings.Web.dll => 0x27787397 => 138
	i32 663517072, ; 97: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 261
	i32 666292255, ; 98: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 206
	i32 672442732, ; 99: System.Collections.Concurrent => 0x2814a96c => 10
	i32 683518922, ; 100: System.Net.Security => 0x28bdabca => 75
	i32 690569205, ; 101: System.Xml.Linq.dll => 0x29293ff5 => 157
	i32 691348768, ; 102: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 276
	i32 693804605, ; 103: System.Windows => 0x295a9e3d => 156
	i32 699345723, ; 104: System.Reflection.Emit => 0x29af2b3b => 94
	i32 700284507, ; 105: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 271
	i32 700358131, ; 106: System.IO.Compression.ZipFile => 0x29be9df3 => 47
	i32 720511267, ; 107: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 275
	i32 722857257, ; 108: System.Runtime.Loader.dll => 0x2b15ed29 => 111
	i32 735137430, ; 109: System.Security.SecureString.dll => 0x2bd14e96 => 131
	i32 748653887, ; 110: Maui.Erweitert.dll => 0x2c9f8d3f => 313
	i32 752232764, ; 111: System.Diagnostics.Contracts.dll => 0x2cd6293c => 27
	i32 755313932, ; 112: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 196
	i32 759454413, ; 113: System.Net.Requests => 0x2d445acd => 74
	i32 762598435, ; 114: System.IO.Pipes.dll => 0x2d745423 => 57
	i32 775507847, ; 115: System.IO.Compression => 0x2e394f87 => 48
	i32 777317022, ; 116: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 303
	i32 789151979, ; 117: Microsoft.Extensions.Options => 0x2f0980eb => 186
	i32 790371945, ; 118: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 220
	i32 804715423, ; 119: System.Data.Common => 0x2ff6fb9f => 24
	i32 807930345, ; 120: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 234
	i32 823281589, ; 121: System.Private.Uri.dll => 0x311247b5 => 88
	i32 830298997, ; 122: System.IO.Compression.Brotli => 0x317d5b75 => 45
	i32 832635846, ; 123: System.Xml.XPath.dll => 0x31a103c6 => 162
	i32 834051424, ; 124: System.Net.Quic => 0x31b69d60 => 73
	i32 843511501, ; 125: Xamarin.AndroidX.Print => 0x3246f6cd => 247
	i32 869139383, ; 126: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 288
	i32 873119928, ; 127: Microsoft.VisualBasic => 0x340ac0b8 => 5
	i32 877678880, ; 128: System.Globalization.dll => 0x34505120 => 44
	i32 878954865, ; 129: System.Net.Http.Json => 0x3463c971 => 65
	i32 880668424, ; 130: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 302
	i32 904024072, ; 131: System.ComponentModel.Primitives.dll => 0x35e25008 => 18
	i32 911108515, ; 132: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 55
	i32 918734561, ; 133: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 299
	i32 928116545, ; 134: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 270
	i32 952186615, ; 135: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 107
	i32 955402788, ; 136: Newtonsoft.Json => 0x38f24a24 => 194
	i32 956575887, ; 137: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 275
	i32 961460050, ; 138: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 292
	i32 966729478, ; 139: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 268
	i32 967690846, ; 140: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 231
	i32 975236339, ; 141: System.Diagnostics.Tracing => 0x3a20ecf3 => 36
	i32 975874589, ; 142: System.Xml.XDocument => 0x3a2aaa1d => 160
	i32 986514023, ; 143: System.Private.DataContractSerialization.dll => 0x3acd0267 => 87
	i32 987214855, ; 144: System.Diagnostics.Tools => 0x3ad7b407 => 34
	i32 990727110, ; 145: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 301
	i32 992768348, ; 146: System.Collections.dll => 0x3b2c715c => 14
	i32 994442037, ; 147: System.IO.FileSystem => 0x3b45fb35 => 53
	i32 1001831731, ; 148: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 58
	i32 1012816738, ; 149: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 251
	i32 1019214401, ; 150: System.Drawing => 0x3cbffa41 => 38
	i32 1028951442, ; 151: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 182
	i32 1031528504, ; 152: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 269
	i32 1035644815, ; 153: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 204
	i32 1036536393, ; 154: System.Drawing.Primitives.dll => 0x3dc84a49 => 37
	i32 1043950537, ; 155: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 282
	i32 1044663988, ; 156: System.Linq.Expressions.dll => 0x3e444eb4 => 60
	i32 1052210849, ; 157: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 238
	i32 1067306892, ; 158: GoogleGson => 0x3f9dcf8c => 178
	i32 1082857460, ; 159: System.ComponentModel.TypeConverter => 0x408b17f4 => 19
	i32 1084122840, ; 160: Xamarin.Kotlin.StdLib => 0x409e66d8 => 272
	i32 1098259244, ; 161: System => 0x41761b2c => 166
	i32 1108272742, ; 162: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 304
	i32 1117529484, ; 163: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 298
	i32 1118262833, ; 164: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 294
	i32 1121599056, ; 165: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 237
	i32 1127624469, ; 166: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 185
	i32 1149092582, ; 167: Xamarin.AndroidX.Window => 0x447dc2e6 => 264
	i32 1168523401, ; 168: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 300
	i32 1170634674, ; 169: System.Web.dll => 0x45c677b2 => 155
	i32 1175144683, ; 170: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 260
	i32 1178241025, ; 171: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 245
	i32 1204270330, ; 172: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 206
	i32 1208641965, ; 173: System.Diagnostics.Process => 0x480a69ad => 31
	i32 1214827643, ; 174: CommunityToolkit.Mvvm => 0x4868cc7b => 177
	i32 1219128291, ; 175: System.IO.IsolatedStorage => 0x48aa6be3 => 54
	i32 1243150071, ; 176: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 265
	i32 1253011324, ; 177: Microsoft.Win32.Registry => 0x4aaf6f7c => 7
	i32 1260983243, ; 178: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 280
	i32 1264511973, ; 179: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 255
	i32 1267360935, ; 180: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 259
	i32 1273260888, ; 181: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 211
	i32 1275534314, ; 182: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 276
	i32 1278448581, ; 183: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 203
	i32 1293217323, ; 184: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 222
	i32 1308624726, ; 185: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 289
	i32 1309188875, ; 186: System.Private.DataContractSerialization => 0x4e08a30b => 87
	i32 1322716291, ; 187: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 264
	i32 1324164729, ; 188: System.Linq => 0x4eed2679 => 63
	i32 1335329327, ; 189: System.Runtime.Serialization.Json.dll => 0x4f97822f => 114
	i32 1336711579, ; 190: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 309
	i32 1364015309, ; 191: System.IO => 0x514d38cd => 59
	i32 1373134921, ; 192: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 310
	i32 1376866003, ; 193: Xamarin.AndroidX.SavedState => 0x52114ed3 => 251
	i32 1379779777, ; 194: System.Resources.ResourceManager => 0x523dc4c1 => 101
	i32 1402170036, ; 195: System.Configuration.dll => 0x53936ab4 => 21
	i32 1406073936, ; 196: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 215
	i32 1408764838, ; 197: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 113
	i32 1411638395, ; 198: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 103
	i32 1412154565, ; 199: Maui.Kern => 0x542bc4c5 => 314
	i32 1422545099, ; 200: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 104
	i32 1430672901, ; 201: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 278
	i32 1434145427, ; 202: System.Runtime.Handles => 0x557b5293 => 106
	i32 1435222561, ; 203: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 268
	i32 1439761251, ; 204: System.Net.Quic.dll => 0x55d10363 => 73
	i32 1452070440, ; 205: System.Formats.Asn1.dll => 0x568cd628 => 40
	i32 1453312822, ; 206: System.Diagnostics.Tools.dll => 0x569fcb36 => 34
	i32 1457743152, ; 207: System.Runtime.Extensions.dll => 0x56e36530 => 105
	i32 1458022317, ; 208: System.Net.Security.dll => 0x56e7a7ad => 75
	i32 1461004990, ; 209: es\Microsoft.Maui.Controls.resources => 0x57152abe => 284
	i32 1461234159, ; 210: System.Collections.Immutable.dll => 0x5718a9ef => 11
	i32 1461719063, ; 211: System.Security.Cryptography.OpenSsl => 0x57201017 => 125
	i32 1462112819, ; 212: System.IO.Compression.dll => 0x57261233 => 48
	i32 1469204771, ; 213: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 205
	i32 1470490898, ; 214: Microsoft.Extensions.Primitives => 0x57a5e912 => 187
	i32 1479771757, ; 215: System.Collections.Immutable => 0x5833866d => 11
	i32 1480492111, ; 216: System.IO.Compression.Brotli.dll => 0x583e844f => 45
	i32 1487239319, ; 217: Microsoft.Win32.Primitives => 0x58a57897 => 6
	i32 1490025113, ; 218: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 252
	i32 1526286932, ; 219: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 308
	i32 1536373174, ; 220: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 33
	i32 1543031311, ; 221: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 140
	i32 1543355203, ; 222: System.Reflection.Emit.dll => 0x5bfdbb43 => 94
	i32 1550322496, ; 223: System.Reflection.Extensions.dll => 0x5c680b40 => 95
	i32 1565862583, ; 224: System.IO.FileSystem.Primitives => 0x5d552ab7 => 51
	i32 1566207040, ; 225: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 143
	i32 1573704789, ; 226: System.Runtime.Serialization.Json => 0x5dccd455 => 114
	i32 1580037396, ; 227: System.Threading.Overlapped => 0x5e2d7514 => 142
	i32 1582372066, ; 228: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 221
	i32 1592978981, ; 229: System.Runtime.Serialization.dll => 0x5ef2ee25 => 117
	i32 1597949149, ; 230: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 269
	i32 1601112923, ; 231: System.Xml.Serialization => 0x5f6f0b5b => 159
	i32 1604827217, ; 232: System.Net.WebClient => 0x5fa7b851 => 78
	i32 1618516317, ; 233: System.Net.WebSockets.Client.dll => 0x6078995d => 81
	i32 1622152042, ; 234: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 241
	i32 1622358360, ; 235: System.Dynamic.Runtime => 0x60b33958 => 39
	i32 1624863272, ; 236: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 263
	i32 1634654947, ; 237: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 176
	i32 1635184631, ; 238: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 225
	i32 1636350590, ; 239: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 218
	i32 1639515021, ; 240: System.Net.Http.dll => 0x61b9038d => 66
	i32 1639986890, ; 241: System.Text.RegularExpressions => 0x61c036ca => 140
	i32 1641389582, ; 242: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 17
	i32 1657153582, ; 243: System.Runtime => 0x62c6282e => 118
	i32 1658241508, ; 244: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 257
	i32 1658251792, ; 245: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 266
	i32 1670060433, ; 246: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 213
	i32 1675553242, ; 247: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 50
	i32 1677501392, ; 248: System.Net.Primitives.dll => 0x63fca3d0 => 72
	i32 1678508291, ; 249: System.Net.WebSockets => 0x640c0103 => 82
	i32 1679769178, ; 250: System.Security.Cryptography => 0x641f3e5a => 128
	i32 1691477237, ; 251: System.Reflection.Metadata => 0x64d1e4f5 => 96
	i32 1696967625, ; 252: System.Security.Cryptography.Csp => 0x6525abc9 => 123
	i32 1698840827, ; 253: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 273
	i32 1701541528, ; 254: System.Diagnostics.Debug.dll => 0x656b7698 => 28
	i32 1720223769, ; 255: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 234
	i32 1726116996, ; 256: System.Reflection.dll => 0x66e27484 => 99
	i32 1728033016, ; 257: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 30
	i32 1729485958, ; 258: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 209
	i32 1743415430, ; 259: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 279
	i32 1744735666, ; 260: System.Transactions.Local.dll => 0x67fe8db2 => 151
	i32 1746316138, ; 261: Mono.Android.Export => 0x6816ab6a => 171
	i32 1750313021, ; 262: Microsoft.Win32.Primitives.dll => 0x6853a83d => 6
	i32 1758240030, ; 263: System.Resources.Reader.dll => 0x68cc9d1e => 100
	i32 1763938596, ; 264: System.Diagnostics.TraceSource.dll => 0x69239124 => 35
	i32 1765942094, ; 265: System.Reflection.Extensions => 0x6942234e => 95
	i32 1766324549, ; 266: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 256
	i32 1770582343, ; 267: Microsoft.Extensions.Logging.dll => 0x6988f147 => 183
	i32 1776026572, ; 268: System.Core.dll => 0x69dc03cc => 23
	i32 1777075843, ; 269: System.Globalization.Extensions.dll => 0x69ec0683 => 43
	i32 1780572499, ; 270: Mono.Android.Runtime.dll => 0x6a216153 => 172
	i32 1782862114, ; 271: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 295
	i32 1788241197, ; 272: Xamarin.AndroidX.Fragment => 0x6a96652d => 227
	i32 1793755602, ; 273: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 287
	i32 1808609942, ; 274: Xamarin.AndroidX.Loader => 0x6bcd3296 => 241
	i32 1813058853, ; 275: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 272
	i32 1813201214, ; 276: Xamarin.Google.Android.Material => 0x6c13413e => 266
	i32 1818569960, ; 277: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 246
	i32 1818787751, ; 278: Microsoft.VisualBasic.Core => 0x6c687fa7 => 4
	i32 1824175904, ; 279: System.Text.Encoding.Extensions => 0x6cbab720 => 136
	i32 1824722060, ; 280: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 113
	i32 1828688058, ; 281: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 184
	i32 1847515442, ; 282: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 196
	i32 1853025655, ; 283: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 304
	i32 1858542181, ; 284: System.Linq.Expressions => 0x6ec71a65 => 60
	i32 1870277092, ; 285: System.Reflection.Primitives => 0x6f7a29e4 => 97
	i32 1875935024, ; 286: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 286
	i32 1879696579, ; 287: System.Formats.Tar.dll => 0x7009e4c3 => 41
	i32 1885316902, ; 288: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 207
	i32 1888955245, ; 289: System.Diagnostics.Contracts => 0x70972b6d => 27
	i32 1889954781, ; 290: System.Reflection.Metadata.dll => 0x70a66bdd => 96
	i32 1893218855, ; 291: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 280
	i32 1898237753, ; 292: System.Reflection.DispatchProxy => 0x7124cf39 => 91
	i32 1900610850, ; 293: System.Resources.ResourceManager.dll => 0x71490522 => 101
	i32 1910275211, ; 294: System.Collections.NonGeneric.dll => 0x71dc7c8b => 12
	i32 1939592360, ; 295: System.Private.Xml.Linq => 0x739bd4a8 => 89
	i32 1953182387, ; 296: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 291
	i32 1956758971, ; 297: System.Resources.Writer => 0x74a1c5bb => 102
	i32 1961813231, ; 298: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 253
	i32 1968388702, ; 299: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 179
	i32 1983156543, ; 300: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 273
	i32 1985761444, ; 301: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 198
	i32 2003115576, ; 302: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 283
	i32 2011961780, ; 303: System.Buffers.dll => 0x77ec19b4 => 9
	i32 2019465201, ; 304: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 238
	i32 2031763787, ; 305: Xamarin.Android.Glide => 0x791a414b => 195
	i32 2045470958, ; 306: System.Private.Xml => 0x79eb68ee => 90
	i32 2055257422, ; 307: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 233
	i32 2060060697, ; 308: System.Windows.dll => 0x7aca0819 => 156
	i32 2066184531, ; 309: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 282
	i32 2070888862, ; 310: System.Diagnostics.TraceSource => 0x7b6f419e => 35
	i32 2079903147, ; 311: System.Runtime.dll => 0x7bf8cdab => 118
	i32 2090596640, ; 312: System.Numerics.Vectors => 0x7c9bf920 => 84
	i32 2127167465, ; 313: System.Console => 0x7ec9ffe9 => 22
	i32 2142473426, ; 314: System.Collections.Specialized => 0x7fb38cd2 => 13
	i32 2143790110, ; 315: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 164
	i32 2146852085, ; 316: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 5
	i32 2159891885, ; 317: Microsoft.Maui => 0x80bd55ad => 191
	i32 2169148018, ; 318: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 290
	i32 2181898931, ; 319: Microsoft.Extensions.Options.dll => 0x820d22b3 => 186
	i32 2192057212, ; 320: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 184
	i32 2193016926, ; 321: System.ObjectModel.dll => 0x82b6c85e => 86
	i32 2201107256, ; 322: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 277
	i32 2201231467, ; 323: System.Net.Http => 0x8334206b => 66
	i32 2207618523, ; 324: it\Microsoft.Maui.Controls.resources => 0x839595db => 292
	i32 2217644978, ; 325: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 260
	i32 2222056684, ; 326: System.Threading.Tasks.Parallel => 0x8471e4ec => 145
	i32 2244775296, ; 327: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 242
	i32 2252106437, ; 328: System.Xml.Serialization.dll => 0x863c6ac5 => 159
	i32 2256313426, ; 329: System.Globalization.Extensions => 0x867c9c52 => 43
	i32 2265110946, ; 330: System.Security.AccessControl.dll => 0x8702d9a2 => 119
	i32 2266799131, ; 331: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 180
	i32 2267999099, ; 332: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 197
	i32 2279755925, ; 333: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 249
	i32 2293034957, ; 334: System.ServiceModel.Web.dll => 0x88acefcd => 133
	i32 2295906218, ; 335: System.Net.Sockets => 0x88d8bfaa => 77
	i32 2298471582, ; 336: System.Net.Mail => 0x88ffe49e => 68
	i32 2303942373, ; 337: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 296
	i32 2305521784, ; 338: System.Private.CoreLib.dll => 0x896b7878 => 174
	i32 2315684594, ; 339: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 201
	i32 2320631194, ; 340: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 145
	i32 2340441535, ; 341: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 108
	i32 2344264397, ; 342: System.ValueTuple => 0x8bbaa2cd => 153
	i32 2353062107, ; 343: System.Net.Primitives => 0x8c40e0db => 72
	i32 2366048013, ; 344: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 290
	i32 2368005991, ; 345: System.Xml.ReaderWriter.dll => 0x8d24e767 => 158
	i32 2371007202, ; 346: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 179
	i32 2378619854, ; 347: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 123
	i32 2383496789, ; 348: System.Security.Principal.Windows.dll => 0x8e114655 => 129
	i32 2395872292, ; 349: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 291
	i32 2401565422, ; 350: System.Web.HttpUtility => 0x8f24faee => 154
	i32 2403452196, ; 351: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 224
	i32 2421380589, ; 352: System.Threading.Tasks.Dataflow => 0x905355ed => 143
	i32 2423080555, ; 353: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 211
	i32 2427813419, ; 354: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 288
	i32 2435356389, ; 355: System.Console.dll => 0x912896e5 => 22
	i32 2435904999, ; 356: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 16
	i32 2454642406, ; 357: System.Text.Encoding.dll => 0x924edee6 => 137
	i32 2458678730, ; 358: System.Net.Sockets.dll => 0x928c75ca => 77
	i32 2459001652, ; 359: System.Linq.Parallel.dll => 0x92916334 => 61
	i32 2465532216, ; 360: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 214
	i32 2471841756, ; 361: netstandard.dll => 0x93554fdc => 169
	i32 2475788418, ; 362: Java.Interop.dll => 0x93918882 => 170
	i32 2480646305, ; 363: Microsoft.Maui.Controls => 0x93dba8a1 => 189
	i32 2483903535, ; 364: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 17
	i32 2484371297, ; 365: System.Net.ServicePoint => 0x94147f61 => 76
	i32 2490993605, ; 366: System.AppContext.dll => 0x94798bc5 => 8
	i32 2501346920, ; 367: System.Data.DataSetExtensions => 0x95178668 => 25
	i32 2503351294, ; 368: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 294
	i32 2505896520, ; 369: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 236
	i32 2522472828, ; 370: Xamarin.Android.Glide.dll => 0x9659e17c => 195
	i32 2538310050, ; 371: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 93
	i32 2550873716, ; 372: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 289
	i32 2562349572, ; 373: Microsoft.CSharp => 0x98ba5a04 => 3
	i32 2570120770, ; 374: System.Text.Encodings.Web => 0x9930ee42 => 138
	i32 2576534780, ; 375: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 293
	i32 2581783588, ; 376: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 237
	i32 2581819634, ; 377: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 259
	i32 2585220780, ; 378: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 136
	i32 2585805581, ; 379: System.Net.Ping => 0x9a20430d => 71
	i32 2589602615, ; 380: System.Threading.ThreadPool => 0x9a5a3337 => 148
	i32 2593496499, ; 381: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 298
	i32 2605712449, ; 382: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 277
	i32 2615233544, ; 383: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 228
	i32 2616218305, ; 384: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 185
	i32 2617129537, ; 385: System.Private.Xml.dll => 0x9bfe3a41 => 90
	i32 2618712057, ; 386: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 98
	i32 2620871830, ; 387: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 218
	i32 2624644809, ; 388: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 223
	i32 2626831493, ; 389: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 293
	i32 2627185994, ; 390: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 33
	i32 2629843544, ; 391: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 47
	i32 2633051222, ; 392: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 232
	i32 2663391936, ; 393: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 197
	i32 2663698177, ; 394: System.Runtime.Loader => 0x9ec4cf01 => 111
	i32 2664396074, ; 395: System.Xml.XDocument.dll => 0x9ecf752a => 160
	i32 2665622720, ; 396: System.Drawing.Primitives => 0x9ee22cc0 => 37
	i32 2676780864, ; 397: System.Data.Common.dll => 0x9f8c6f40 => 24
	i32 2686887180, ; 398: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 116
	i32 2693849962, ; 399: System.IO.dll => 0xa090e36a => 59
	i32 2701096212, ; 400: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 257
	i32 2715334215, ; 401: System.Threading.Tasks.dll => 0xa1d8b647 => 146
	i32 2717744543, ; 402: System.Security.Claims => 0xa1fd7d9f => 120
	i32 2719963679, ; 403: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 122
	i32 2724373263, ; 404: System.Runtime.Numerics.dll => 0xa262a30f => 112
	i32 2732626843, ; 405: Xamarin.AndroidX.Activity => 0xa2e0939b => 199
	i32 2735172069, ; 406: System.Threading.Channels => 0xa30769e5 => 141
	i32 2736250344, ; 407: Maui.App.resources => 0xa317dde8 => 1
	i32 2737747696, ; 408: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 205
	i32 2740698338, ; 409: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 279
	i32 2740948882, ; 410: System.IO.Pipes.AccessControl => 0xa35f8f92 => 56
	i32 2748088231, ; 411: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 107
	i32 2752995522, ; 412: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 299
	i32 2758225723, ; 413: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 190
	i32 2764765095, ; 414: Microsoft.Maui.dll => 0xa4caf7a7 => 191
	i32 2765824710, ; 415: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 135
	i32 2770495804, ; 416: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 271
	i32 2778768386, ; 417: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 262
	i32 2779977773, ; 418: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 250
	i32 2785988530, ; 419: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 305
	i32 2788224221, ; 420: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 228
	i32 2801831435, ; 421: Microsoft.Maui.Graphics => 0xa7008e0b => 193
	i32 2803228030, ; 422: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 161
	i32 2810250172, ; 423: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 215
	i32 2819470561, ; 424: System.Xml.dll => 0xa80db4e1 => 165
	i32 2821205001, ; 425: System.ServiceProcess.dll => 0xa8282c09 => 134
	i32 2821294376, ; 426: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 250
	i32 2824502124, ; 427: System.Xml.XmlDocument => 0xa85a7b6c => 163
	i32 2838993487, ; 428: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 239
	i32 2849599387, ; 429: System.Threading.Overlapped.dll => 0xa9d96f9b => 142
	i32 2853208004, ; 430: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 262
	i32 2855708567, ; 431: Xamarin.AndroidX.Transition => 0xaa36a797 => 258
	i32 2861098320, ; 432: Mono.Android.Export.dll => 0xaa88e550 => 171
	i32 2861189240, ; 433: Microsoft.Maui.Essentials => 0xaa8a4878 => 192
	i32 2868488919, ; 434: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 176
	i32 2870099610, ; 435: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 200
	i32 2875164099, ; 436: Jsr305Binding.dll => 0xab5f85c3 => 267
	i32 2875220617, ; 437: System.Globalization.Calendars.dll => 0xab606289 => 42
	i32 2884993177, ; 438: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 226
	i32 2887636118, ; 439: System.Net.dll => 0xac1dd496 => 83
	i32 2899753641, ; 440: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 58
	i32 2900621748, ; 441: System.Dynamic.Runtime.dll => 0xace3f9b4 => 39
	i32 2901442782, ; 442: System.Reflection => 0xacf080de => 99
	i32 2905242038, ; 443: mscorlib.dll => 0xad2a79b6 => 168
	i32 2909740682, ; 444: System.Private.CoreLib => 0xad6f1e8a => 174
	i32 2916838712, ; 445: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 263
	i32 2919462931, ; 446: System.Numerics.Vectors.dll => 0xae037813 => 84
	i32 2921128767, ; 447: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 202
	i32 2931258378, ; 448: Maui.Kern.dll => 0xaeb7740a => 314
	i32 2936416060, ; 449: System.Resources.Reader => 0xaf06273c => 100
	i32 2940926066, ; 450: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 32
	i32 2942453041, ; 451: System.Xml.XPath.XDocument => 0xaf624531 => 161
	i32 2959614098, ; 452: System.ComponentModel.dll => 0xb0682092 => 20
	i32 2968338931, ; 453: System.Security.Principal.Windows => 0xb0ed41f3 => 129
	i32 2972252294, ; 454: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 121
	i32 2978675010, ; 455: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 222
	i32 2987532451, ; 456: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 253
	i32 2996846495, ; 457: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 235
	i32 3016983068, ; 458: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 255
	i32 3023353419, ; 459: WindowsBase.dll => 0xb434b64b => 167
	i32 3024354802, ; 460: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 230
	i32 3038032645, ; 461: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 315
	i32 3053864966, ; 462: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 285
	i32 3056245963, ; 463: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 252
	i32 3057625584, ; 464: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 243
	i32 3059408633, ; 465: Mono.Android.Runtime => 0xb65adef9 => 172
	i32 3059793426, ; 466: System.ComponentModel.Primitives => 0xb660be12 => 18
	i32 3075834255, ; 467: System.Threading.Tasks => 0xb755818f => 146
	i32 3090735792, ; 468: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 127
	i32 3099732863, ; 469: System.Security.Claims.dll => 0xb8c22b7f => 120
	i32 3103600923, ; 470: System.Formats.Asn1 => 0xb8fd311b => 40
	i32 3111772706, ; 471: System.Runtime.Serialization => 0xb979e222 => 117
	i32 3121463068, ; 472: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 49
	i32 3121923764, ; 473: Maui.App.dll => 0xba14c6b4 => 2
	i32 3124832203, ; 474: System.Threading.Tasks.Extensions => 0xba4127cb => 144
	i32 3132293585, ; 475: System.Security.AccessControl => 0xbab301d1 => 119
	i32 3147165239, ; 476: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 36
	i32 3148237826, ; 477: GoogleGson.dll => 0xbba64c02 => 178
	i32 3159123045, ; 478: System.Reflection.Primitives.dll => 0xbc4c6465 => 97
	i32 3160747431, ; 479: System.IO.MemoryMappedFiles => 0xbc652da7 => 55
	i32 3178803400, ; 480: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 244
	i32 3192346100, ; 481: System.Security.SecureString => 0xbe4755f4 => 131
	i32 3193515020, ; 482: System.Web => 0xbe592c0c => 155
	i32 3204380047, ; 483: System.Data.dll => 0xbefef58f => 26
	i32 3209718065, ; 484: System.Xml.XmlDocument.dll => 0xbf506931 => 163
	i32 3211777861, ; 485: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 221
	i32 3220365878, ; 486: System.Threading => 0xbff2e236 => 150
	i32 3226221578, ; 487: System.Runtime.Handles.dll => 0xc04c3c0a => 106
	i32 3251039220, ; 488: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 91
	i32 3258312781, ; 489: Xamarin.AndroidX.CardView => 0xc235e84d => 209
	i32 3265493905, ; 490: System.Linq.Queryable.dll => 0xc2a37b91 => 62
	i32 3265893370, ; 491: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 144
	i32 3277815716, ; 492: System.Resources.Writer.dll => 0xc35f7fa4 => 102
	i32 3279906254, ; 493: Microsoft.Win32.Registry.dll => 0xc37f65ce => 7
	i32 3280506390, ; 494: System.ComponentModel.Annotations.dll => 0xc3888e16 => 15
	i32 3290767353, ; 495: System.Security.Cryptography.Encoding => 0xc4251ff9 => 124
	i32 3299363146, ; 496: System.Text.Encoding => 0xc4a8494a => 137
	i32 3303498502, ; 497: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 30
	i32 3305363605, ; 498: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 285
	i32 3316684772, ; 499: System.Net.Requests.dll => 0xc5b097e4 => 74
	i32 3317135071, ; 500: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 219
	i32 3317144872, ; 501: System.Data => 0xc5b79d28 => 26
	i32 3340431453, ; 502: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 207
	i32 3345895724, ; 503: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 248
	i32 3346324047, ; 504: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 245
	i32 3357674450, ; 505: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 302
	i32 3358260929, ; 506: System.Text.Json => 0xc82afec1 => 139
	i32 3362336904, ; 507: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 200
	i32 3362522851, ; 508: Xamarin.AndroidX.Core => 0xc86c06e3 => 216
	i32 3366347497, ; 509: Java.Interop => 0xc8a662e9 => 170
	i32 3374999561, ; 510: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 249
	i32 3381016424, ; 511: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 281
	i32 3395150330, ; 512: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 103
	i32 3403906625, ; 513: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 125
	i32 3405233483, ; 514: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 220
	i32 3428513518, ; 515: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 181
	i32 3429136800, ; 516: System.Xml => 0xcc6479a0 => 165
	i32 3430777524, ; 517: netstandard => 0xcc7d82b4 => 169
	i32 3441283291, ; 518: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 223
	i32 3445260447, ; 519: System.Formats.Tar => 0xcd5a809f => 41
	i32 3452344032, ; 520: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 188
	i32 3458724246, ; 521: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 300
	i32 3459457652, ; 522: Maui.Erweitert => 0xce332274 => 313
	i32 3471940407, ; 523: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 19
	i32 3476120550, ; 524: Mono.Android => 0xcf3163e6 => 173
	i32 3484440000, ; 525: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 301
	i32 3485117614, ; 526: System.Text.Json.dll => 0xcfbaacae => 139
	i32 3486566296, ; 527: System.Transactions => 0xcfd0c798 => 152
	i32 3493954962, ; 528: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 212
	i32 3509114376, ; 529: System.Xml.Linq => 0xd128d608 => 157
	i32 3515174580, ; 530: System.Security.dll => 0xd1854eb4 => 132
	i32 3530912306, ; 531: System.Configuration => 0xd2757232 => 21
	i32 3539954161, ; 532: System.Net.HttpListener => 0xd2ff69f1 => 67
	i32 3560100363, ; 533: System.Threading.Timer => 0xd432d20b => 149
	i32 3570554715, ; 534: System.IO.FileSystem.AccessControl => 0xd4d2575b => 49
	i32 3580758918, ; 535: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 309
	i32 3592228221, ; 536: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 311
	i32 3597029428, ; 537: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 198
	i32 3598340787, ; 538: System.Net.WebSockets.Client => 0xd67a52b3 => 81
	i32 3608519521, ; 539: System.Linq.dll => 0xd715a361 => 63
	i32 3624195450, ; 540: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 108
	i32 3627220390, ; 541: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 247
	i32 3633644679, ; 542: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 202
	i32 3638274909, ; 543: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 51
	i32 3641597786, ; 544: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 233
	i32 3643446276, ; 545: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 306
	i32 3643854240, ; 546: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 244
	i32 3645089577, ; 547: System.ComponentModel.DataAnnotations => 0xd943a729 => 16
	i32 3657292374, ; 548: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 180
	i32 3660523487, ; 549: System.Net.NetworkInformation => 0xda2f27df => 70
	i32 3672681054, ; 550: Mono.Android.dll => 0xdae8aa5e => 173
	i32 3682565725, ; 551: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 208
	i32 3684561358, ; 552: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 212
	i32 3700866549, ; 553: System.Net.WebProxy.dll => 0xdc96bdf5 => 80
	i32 3706696989, ; 554: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 217
	i32 3716563718, ; 555: System.Runtime.Intrinsics => 0xdd864306 => 110
	i32 3718780102, ; 556: Xamarin.AndroidX.Annotation => 0xdda814c6 => 201
	i32 3724971120, ; 557: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 243
	i32 3732100267, ; 558: System.Net.NameResolution => 0xde7354ab => 69
	i32 3737834244, ; 559: System.Net.Http.Json.dll => 0xdecad304 => 65
	i32 3748608112, ; 560: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 29
	i32 3751444290, ; 561: System.Xml.XPath => 0xdf9a7f42 => 162
	i32 3751619990, ; 562: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 281
	i32 3786282454, ; 563: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 210
	i32 3792276235, ; 564: System.Collections.NonGeneric => 0xe2098b0b => 12
	i32 3800979733, ; 565: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 188
	i32 3802395368, ; 566: System.Collections.Specialized.dll => 0xe2a3f2e8 => 13
	i32 3817368567, ; 567: CommunityToolkit.Maui.dll => 0xe3886bf7 => 175
	i32 3819260425, ; 568: System.Net.WebProxy => 0xe3a54a09 => 80
	i32 3823082795, ; 569: System.Security.Cryptography.dll => 0xe3df9d2b => 128
	i32 3829621856, ; 570: System.Numerics.dll => 0xe4436460 => 85
	i32 3841636137, ; 571: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 182
	i32 3844307129, ; 572: System.Net.Mail.dll => 0xe52378b9 => 68
	i32 3849253459, ; 573: System.Runtime.InteropServices.dll => 0xe56ef253 => 109
	i32 3870376305, ; 574: System.Net.HttpListener.dll => 0xe6b14171 => 67
	i32 3873536506, ; 575: System.Security.Principal => 0xe6e179fa => 130
	i32 3875112723, ; 576: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 124
	i32 3885497537, ; 577: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 79
	i32 3885922214, ; 578: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 258
	i32 3888767677, ; 579: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 248
	i32 3889925288, ; 580: Maui.DatenObjekte.dll => 0xe7db8ca8 => 312
	i32 3896106733, ; 581: System.Collections.Concurrent.dll => 0xe839deed => 10
	i32 3896760992, ; 582: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 216
	i32 3901907137, ; 583: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 4
	i32 3920221145, ; 584: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 297
	i32 3920810846, ; 585: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 46
	i32 3921031405, ; 586: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 261
	i32 3928044579, ; 587: System.Xml.ReaderWriter => 0xea213423 => 158
	i32 3928240828, ; 588: Maui.App => 0xea2432bc => 2
	i32 3930554604, ; 589: System.Security.Principal.dll => 0xea4780ec => 130
	i32 3931092270, ; 590: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 246
	i32 3945713374, ; 591: System.Data.DataSetExtensions.dll => 0xeb2ecede => 25
	i32 3953953790, ; 592: System.Text.Encoding.CodePages => 0xebac8bfe => 135
	i32 3955647286, ; 593: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 204
	i32 3959773229, ; 594: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 235
	i32 4003436829, ; 595: System.Diagnostics.Process.dll => 0xee9f991d => 31
	i32 4015948917, ; 596: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 203
	i32 4025784931, ; 597: System.Memory => 0xeff49a63 => 64
	i32 4046471985, ; 598: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 190
	i32 4054681211, ; 599: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 92
	i32 4068434129, ; 600: System.Private.Xml.Linq.dll => 0xf27f60d1 => 89
	i32 4073602200, ; 601: System.Threading.dll => 0xf2ce3c98 => 150
	i32 4091086043, ; 602: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 283
	i32 4094352644, ; 603: Microsoft.Maui.Essentials.dll => 0xf40add04 => 192
	i32 4099507663, ; 604: System.Drawing.dll => 0xf45985cf => 38
	i32 4100113165, ; 605: System.Private.Uri => 0xf462c30d => 88
	i32 4101593132, ; 606: Xamarin.AndroidX.Emoji2 => 0xf479582c => 224
	i32 4103439459, ; 607: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 307
	i32 4121273868, ; 608: Maui.App.resources.dll => 0xf5a5a60c => 1
	i32 4126470640, ; 609: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 181
	i32 4127667938, ; 610: System.IO.FileSystem.Watcher => 0xf60736e2 => 52
	i32 4130442656, ; 611: System.AppContext => 0xf6318da0 => 8
	i32 4147896353, ; 612: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 92
	i32 4150914736, ; 613: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 307
	i32 4151237749, ; 614: System.Core => 0xf76edc75 => 23
	i32 4159265925, ; 615: System.Xml.XmlSerializer => 0xf7e95c85 => 164
	i32 4161255271, ; 616: System.Reflection.TypeExtensions => 0xf807b767 => 98
	i32 4164802419, ; 617: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 52
	i32 4181436372, ; 618: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 115
	i32 4182413190, ; 619: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 240
	i32 4185676441, ; 620: System.Security => 0xf97c5a99 => 132
	i32 4196529839, ; 621: System.Net.WebClient.dll => 0xfa21f6af => 78
	i32 4213026141, ; 622: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 29
	i32 4249188766, ; 623: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 296
	i32 4256097574, ; 624: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 217
	i32 4258378803, ; 625: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 239
	i32 4260525087, ; 626: System.Buffers => 0xfdf2741f => 9
	i32 4271975918, ; 627: Microsoft.Maui.Controls.dll => 0xfea12dee => 189
	i32 4274623895, ; 628: CommunityToolkit.Mvvm.dll => 0xfec99597 => 177
	i32 4274976490, ; 629: System.Runtime.Numerics => 0xfecef6ea => 112
	i32 4292120959, ; 630: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 240
	i32 4294763496 ; 631: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 226
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [632 x i32] [
	i32 70, ; 0
	i32 69, ; 1
	i32 110, ; 2
	i32 236, ; 3
	i32 270, ; 4
	i32 50, ; 5
	i32 278, ; 6
	i32 194, ; 7
	i32 82, ; 8
	i32 287, ; 9
	i32 147, ; 10
	i32 32, ; 11
	i32 311, ; 12
	i32 126, ; 13
	i32 193, ; 14
	i32 104, ; 15
	i32 295, ; 16
	i32 254, ; 17
	i32 109, ; 18
	i32 254, ; 19
	i32 141, ; 20
	i32 274, ; 21
	i32 310, ; 22
	i32 303, ; 23
	i32 79, ; 24
	i32 126, ; 25
	i32 15, ; 26
	i32 210, ; 27
	i32 134, ; 28
	i32 312, ; 29
	i32 256, ; 30
	i32 153, ; 31
	i32 0, ; 32
	i32 20, ; 33
	i32 208, ; 34
	i32 28, ; 35
	i32 230, ; 36
	i32 3, ; 37
	i32 61, ; 38
	i32 44, ; 39
	i32 93, ; 40
	i32 213, ; 41
	i32 149, ; 42
	i32 232, ; 43
	i32 229, ; 44
	i32 56, ; 45
	i32 71, ; 46
	i32 308, ; 47
	i32 199, ; 48
	i32 85, ; 49
	i32 286, ; 50
	i32 231, ; 51
	i32 133, ; 52
	i32 57, ; 53
	i32 151, ; 54
	i32 76, ; 55
	i32 147, ; 56
	i32 64, ; 57
	i32 148, ; 58
	i32 315, ; 59
	i32 167, ; 60
	i32 306, ; 61
	i32 214, ; 62
	i32 14, ; 63
	i32 227, ; 64
	i32 127, ; 65
	i32 154, ; 66
	i32 115, ; 67
	i32 168, ; 68
	i32 166, ; 69
	i32 229, ; 70
	i32 242, ; 71
	i32 284, ; 72
	i32 86, ; 73
	i32 187, ; 74
	i32 152, ; 75
	i32 274, ; 76
	i32 62, ; 77
	i32 305, ; 78
	i32 183, ; 79
	i32 53, ; 80
	i32 105, ; 81
	i32 116, ; 82
	i32 42, ; 83
	i32 267, ; 84
	i32 265, ; 85
	i32 122, ; 86
	i32 0, ; 87
	i32 175, ; 88
	i32 54, ; 89
	i32 46, ; 90
	i32 121, ; 91
	i32 219, ; 92
	i32 297, ; 93
	i32 225, ; 94
	i32 83, ; 95
	i32 138, ; 96
	i32 261, ; 97
	i32 206, ; 98
	i32 10, ; 99
	i32 75, ; 100
	i32 157, ; 101
	i32 276, ; 102
	i32 156, ; 103
	i32 94, ; 104
	i32 271, ; 105
	i32 47, ; 106
	i32 275, ; 107
	i32 111, ; 108
	i32 131, ; 109
	i32 313, ; 110
	i32 27, ; 111
	i32 196, ; 112
	i32 74, ; 113
	i32 57, ; 114
	i32 48, ; 115
	i32 303, ; 116
	i32 186, ; 117
	i32 220, ; 118
	i32 24, ; 119
	i32 234, ; 120
	i32 88, ; 121
	i32 45, ; 122
	i32 162, ; 123
	i32 73, ; 124
	i32 247, ; 125
	i32 288, ; 126
	i32 5, ; 127
	i32 44, ; 128
	i32 65, ; 129
	i32 302, ; 130
	i32 18, ; 131
	i32 55, ; 132
	i32 299, ; 133
	i32 270, ; 134
	i32 107, ; 135
	i32 194, ; 136
	i32 275, ; 137
	i32 292, ; 138
	i32 268, ; 139
	i32 231, ; 140
	i32 36, ; 141
	i32 160, ; 142
	i32 87, ; 143
	i32 34, ; 144
	i32 301, ; 145
	i32 14, ; 146
	i32 53, ; 147
	i32 58, ; 148
	i32 251, ; 149
	i32 38, ; 150
	i32 182, ; 151
	i32 269, ; 152
	i32 204, ; 153
	i32 37, ; 154
	i32 282, ; 155
	i32 60, ; 156
	i32 238, ; 157
	i32 178, ; 158
	i32 19, ; 159
	i32 272, ; 160
	i32 166, ; 161
	i32 304, ; 162
	i32 298, ; 163
	i32 294, ; 164
	i32 237, ; 165
	i32 185, ; 166
	i32 264, ; 167
	i32 300, ; 168
	i32 155, ; 169
	i32 260, ; 170
	i32 245, ; 171
	i32 206, ; 172
	i32 31, ; 173
	i32 177, ; 174
	i32 54, ; 175
	i32 265, ; 176
	i32 7, ; 177
	i32 280, ; 178
	i32 255, ; 179
	i32 259, ; 180
	i32 211, ; 181
	i32 276, ; 182
	i32 203, ; 183
	i32 222, ; 184
	i32 289, ; 185
	i32 87, ; 186
	i32 264, ; 187
	i32 63, ; 188
	i32 114, ; 189
	i32 309, ; 190
	i32 59, ; 191
	i32 310, ; 192
	i32 251, ; 193
	i32 101, ; 194
	i32 21, ; 195
	i32 215, ; 196
	i32 113, ; 197
	i32 103, ; 198
	i32 314, ; 199
	i32 104, ; 200
	i32 278, ; 201
	i32 106, ; 202
	i32 268, ; 203
	i32 73, ; 204
	i32 40, ; 205
	i32 34, ; 206
	i32 105, ; 207
	i32 75, ; 208
	i32 284, ; 209
	i32 11, ; 210
	i32 125, ; 211
	i32 48, ; 212
	i32 205, ; 213
	i32 187, ; 214
	i32 11, ; 215
	i32 45, ; 216
	i32 6, ; 217
	i32 252, ; 218
	i32 308, ; 219
	i32 33, ; 220
	i32 140, ; 221
	i32 94, ; 222
	i32 95, ; 223
	i32 51, ; 224
	i32 143, ; 225
	i32 114, ; 226
	i32 142, ; 227
	i32 221, ; 228
	i32 117, ; 229
	i32 269, ; 230
	i32 159, ; 231
	i32 78, ; 232
	i32 81, ; 233
	i32 241, ; 234
	i32 39, ; 235
	i32 263, ; 236
	i32 176, ; 237
	i32 225, ; 238
	i32 218, ; 239
	i32 66, ; 240
	i32 140, ; 241
	i32 17, ; 242
	i32 118, ; 243
	i32 257, ; 244
	i32 266, ; 245
	i32 213, ; 246
	i32 50, ; 247
	i32 72, ; 248
	i32 82, ; 249
	i32 128, ; 250
	i32 96, ; 251
	i32 123, ; 252
	i32 273, ; 253
	i32 28, ; 254
	i32 234, ; 255
	i32 99, ; 256
	i32 30, ; 257
	i32 209, ; 258
	i32 279, ; 259
	i32 151, ; 260
	i32 171, ; 261
	i32 6, ; 262
	i32 100, ; 263
	i32 35, ; 264
	i32 95, ; 265
	i32 256, ; 266
	i32 183, ; 267
	i32 23, ; 268
	i32 43, ; 269
	i32 172, ; 270
	i32 295, ; 271
	i32 227, ; 272
	i32 287, ; 273
	i32 241, ; 274
	i32 272, ; 275
	i32 266, ; 276
	i32 246, ; 277
	i32 4, ; 278
	i32 136, ; 279
	i32 113, ; 280
	i32 184, ; 281
	i32 196, ; 282
	i32 304, ; 283
	i32 60, ; 284
	i32 97, ; 285
	i32 286, ; 286
	i32 41, ; 287
	i32 207, ; 288
	i32 27, ; 289
	i32 96, ; 290
	i32 280, ; 291
	i32 91, ; 292
	i32 101, ; 293
	i32 12, ; 294
	i32 89, ; 295
	i32 291, ; 296
	i32 102, ; 297
	i32 253, ; 298
	i32 179, ; 299
	i32 273, ; 300
	i32 198, ; 301
	i32 283, ; 302
	i32 9, ; 303
	i32 238, ; 304
	i32 195, ; 305
	i32 90, ; 306
	i32 233, ; 307
	i32 156, ; 308
	i32 282, ; 309
	i32 35, ; 310
	i32 118, ; 311
	i32 84, ; 312
	i32 22, ; 313
	i32 13, ; 314
	i32 164, ; 315
	i32 5, ; 316
	i32 191, ; 317
	i32 290, ; 318
	i32 186, ; 319
	i32 184, ; 320
	i32 86, ; 321
	i32 277, ; 322
	i32 66, ; 323
	i32 292, ; 324
	i32 260, ; 325
	i32 145, ; 326
	i32 242, ; 327
	i32 159, ; 328
	i32 43, ; 329
	i32 119, ; 330
	i32 180, ; 331
	i32 197, ; 332
	i32 249, ; 333
	i32 133, ; 334
	i32 77, ; 335
	i32 68, ; 336
	i32 296, ; 337
	i32 174, ; 338
	i32 201, ; 339
	i32 145, ; 340
	i32 108, ; 341
	i32 153, ; 342
	i32 72, ; 343
	i32 290, ; 344
	i32 158, ; 345
	i32 179, ; 346
	i32 123, ; 347
	i32 129, ; 348
	i32 291, ; 349
	i32 154, ; 350
	i32 224, ; 351
	i32 143, ; 352
	i32 211, ; 353
	i32 288, ; 354
	i32 22, ; 355
	i32 16, ; 356
	i32 137, ; 357
	i32 77, ; 358
	i32 61, ; 359
	i32 214, ; 360
	i32 169, ; 361
	i32 170, ; 362
	i32 189, ; 363
	i32 17, ; 364
	i32 76, ; 365
	i32 8, ; 366
	i32 25, ; 367
	i32 294, ; 368
	i32 236, ; 369
	i32 195, ; 370
	i32 93, ; 371
	i32 289, ; 372
	i32 3, ; 373
	i32 138, ; 374
	i32 293, ; 375
	i32 237, ; 376
	i32 259, ; 377
	i32 136, ; 378
	i32 71, ; 379
	i32 148, ; 380
	i32 298, ; 381
	i32 277, ; 382
	i32 228, ; 383
	i32 185, ; 384
	i32 90, ; 385
	i32 98, ; 386
	i32 218, ; 387
	i32 223, ; 388
	i32 293, ; 389
	i32 33, ; 390
	i32 47, ; 391
	i32 232, ; 392
	i32 197, ; 393
	i32 111, ; 394
	i32 160, ; 395
	i32 37, ; 396
	i32 24, ; 397
	i32 116, ; 398
	i32 59, ; 399
	i32 257, ; 400
	i32 146, ; 401
	i32 120, ; 402
	i32 122, ; 403
	i32 112, ; 404
	i32 199, ; 405
	i32 141, ; 406
	i32 1, ; 407
	i32 205, ; 408
	i32 279, ; 409
	i32 56, ; 410
	i32 107, ; 411
	i32 299, ; 412
	i32 190, ; 413
	i32 191, ; 414
	i32 135, ; 415
	i32 271, ; 416
	i32 262, ; 417
	i32 250, ; 418
	i32 305, ; 419
	i32 228, ; 420
	i32 193, ; 421
	i32 161, ; 422
	i32 215, ; 423
	i32 165, ; 424
	i32 134, ; 425
	i32 250, ; 426
	i32 163, ; 427
	i32 239, ; 428
	i32 142, ; 429
	i32 262, ; 430
	i32 258, ; 431
	i32 171, ; 432
	i32 192, ; 433
	i32 176, ; 434
	i32 200, ; 435
	i32 267, ; 436
	i32 42, ; 437
	i32 226, ; 438
	i32 83, ; 439
	i32 58, ; 440
	i32 39, ; 441
	i32 99, ; 442
	i32 168, ; 443
	i32 174, ; 444
	i32 263, ; 445
	i32 84, ; 446
	i32 202, ; 447
	i32 314, ; 448
	i32 100, ; 449
	i32 32, ; 450
	i32 161, ; 451
	i32 20, ; 452
	i32 129, ; 453
	i32 121, ; 454
	i32 222, ; 455
	i32 253, ; 456
	i32 235, ; 457
	i32 255, ; 458
	i32 167, ; 459
	i32 230, ; 460
	i32 315, ; 461
	i32 285, ; 462
	i32 252, ; 463
	i32 243, ; 464
	i32 172, ; 465
	i32 18, ; 466
	i32 146, ; 467
	i32 127, ; 468
	i32 120, ; 469
	i32 40, ; 470
	i32 117, ; 471
	i32 49, ; 472
	i32 2, ; 473
	i32 144, ; 474
	i32 119, ; 475
	i32 36, ; 476
	i32 178, ; 477
	i32 97, ; 478
	i32 55, ; 479
	i32 244, ; 480
	i32 131, ; 481
	i32 155, ; 482
	i32 26, ; 483
	i32 163, ; 484
	i32 221, ; 485
	i32 150, ; 486
	i32 106, ; 487
	i32 91, ; 488
	i32 209, ; 489
	i32 62, ; 490
	i32 144, ; 491
	i32 102, ; 492
	i32 7, ; 493
	i32 15, ; 494
	i32 124, ; 495
	i32 137, ; 496
	i32 30, ; 497
	i32 285, ; 498
	i32 74, ; 499
	i32 219, ; 500
	i32 26, ; 501
	i32 207, ; 502
	i32 248, ; 503
	i32 245, ; 504
	i32 302, ; 505
	i32 139, ; 506
	i32 200, ; 507
	i32 216, ; 508
	i32 170, ; 509
	i32 249, ; 510
	i32 281, ; 511
	i32 103, ; 512
	i32 125, ; 513
	i32 220, ; 514
	i32 181, ; 515
	i32 165, ; 516
	i32 169, ; 517
	i32 223, ; 518
	i32 41, ; 519
	i32 188, ; 520
	i32 300, ; 521
	i32 313, ; 522
	i32 19, ; 523
	i32 173, ; 524
	i32 301, ; 525
	i32 139, ; 526
	i32 152, ; 527
	i32 212, ; 528
	i32 157, ; 529
	i32 132, ; 530
	i32 21, ; 531
	i32 67, ; 532
	i32 149, ; 533
	i32 49, ; 534
	i32 309, ; 535
	i32 311, ; 536
	i32 198, ; 537
	i32 81, ; 538
	i32 63, ; 539
	i32 108, ; 540
	i32 247, ; 541
	i32 202, ; 542
	i32 51, ; 543
	i32 233, ; 544
	i32 306, ; 545
	i32 244, ; 546
	i32 16, ; 547
	i32 180, ; 548
	i32 70, ; 549
	i32 173, ; 550
	i32 208, ; 551
	i32 212, ; 552
	i32 80, ; 553
	i32 217, ; 554
	i32 110, ; 555
	i32 201, ; 556
	i32 243, ; 557
	i32 69, ; 558
	i32 65, ; 559
	i32 29, ; 560
	i32 162, ; 561
	i32 281, ; 562
	i32 210, ; 563
	i32 12, ; 564
	i32 188, ; 565
	i32 13, ; 566
	i32 175, ; 567
	i32 80, ; 568
	i32 128, ; 569
	i32 85, ; 570
	i32 182, ; 571
	i32 68, ; 572
	i32 109, ; 573
	i32 67, ; 574
	i32 130, ; 575
	i32 124, ; 576
	i32 79, ; 577
	i32 258, ; 578
	i32 248, ; 579
	i32 312, ; 580
	i32 10, ; 581
	i32 216, ; 582
	i32 4, ; 583
	i32 297, ; 584
	i32 46, ; 585
	i32 261, ; 586
	i32 158, ; 587
	i32 2, ; 588
	i32 130, ; 589
	i32 246, ; 590
	i32 25, ; 591
	i32 135, ; 592
	i32 204, ; 593
	i32 235, ; 594
	i32 31, ; 595
	i32 203, ; 596
	i32 64, ; 597
	i32 190, ; 598
	i32 92, ; 599
	i32 89, ; 600
	i32 150, ; 601
	i32 283, ; 602
	i32 192, ; 603
	i32 38, ; 604
	i32 88, ; 605
	i32 224, ; 606
	i32 307, ; 607
	i32 1, ; 608
	i32 181, ; 609
	i32 52, ; 610
	i32 8, ; 611
	i32 92, ; 612
	i32 307, ; 613
	i32 23, ; 614
	i32 164, ; 615
	i32 98, ; 616
	i32 52, ; 617
	i32 115, ; 618
	i32 240, ; 619
	i32 132, ; 620
	i32 78, ; 621
	i32 29, ; 622
	i32 296, ; 623
	i32 217, ; 624
	i32 239, ; 625
	i32 9, ; 626
	i32 189, ; 627
	i32 177, ; 628
	i32 112, ; 629
	i32 240, ; 630
	i32 226 ; 631
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
