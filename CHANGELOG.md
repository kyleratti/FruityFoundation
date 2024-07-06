Changelog
<a name="1.12.1"></a>
## [1.12.1](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.12.1) (2024-07-06)

<a name="1.12.0"></a>
## [1.12.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.12.0) (2024-07-06)

### Features

* add FSharp database abstraction layer ([d745706](https://www.github.com/kyleratti/FruityFoundation/commit/d7457060829e897c726f5d7522f56bfac11b8e9a))

<a name="1.11.0"></a>
## [1.11.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.11.0) (2024-07-06)

### Features

* add data access DI helper ([6cbccd3](https://www.github.com/kyleratti/FruityFoundation/commit/6cbccd3d7dd8308bd6e65fd28362f36c61dedd5e))

<a name="1.10.0"></a>
## [1.10.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.10.0) (2024-06-24)

### Features

* initial port of data access ([de8e30d](https://www.github.com/kyleratti/FruityFoundation/commit/de8e30dbb41d8d70b685324847b07f7800e31488))
* make data access layer generic ([1266932](https://www.github.com/kyleratti/FruityFoundation/commit/1266932d4e5f76adb6a181234e644a74da273fa0))
* multi target .NET 6 and .NET 8 ([2242fe8](https://www.github.com/kyleratti/FruityFoundation/commit/2242fe8733f808fb6055baa14cf28123a31fa9dc))

### Bug Fixes

* add missing version node ([90c0740](https://www.github.com/kyleratti/FruityFoundation/commit/90c074077806f0e470081463480a716bcf552b0c))
* include license file ([f169ca3](https://www.github.com/kyleratti/FruityFoundation/commit/f169ca3287116ee17c5e32485af8a9b9107603b8))

<a name="1.9.0"></a>
## [1.9.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.9.0) (2024-05-03)

### Features

* add async extensions support for DbDataReader ([35d1742](https://www.github.com/kyleratti/FruityFoundation/commit/35d1742f00a35712c2be38f0151db343cf1405d3))
* add cancellation token support to DbDataReaderExtensions ([04f94c2](https://www.github.com/kyleratti/FruityFoundation/commit/04f94c2441fc5f589c8a7ec7f4565f144e2d2d73))
* add Maybe.TryParse ([b6f2ef3](https://www.github.com/kyleratti/FruityFoundation/commit/b6f2ef3aa6318a25fe771ae8aa7c15eb476d6b07))
* specify ConfigureAwait(false) on async calls ([190db94](https://www.github.com/kyleratti/FruityFoundation/commit/190db946029f02035fbb7e345bb1210476c39441))

<a name="1.8.1"></a>
## [1.8.1](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.8.1) (2024-2-8)

### 🐛 Bug Fixes

* handle nullable value types in Maybe.Cast ([a56a4ff](https://www.github.com/kyleratti/FruityFoundation/commit/a56a4ff5f2bdb71fcf6d355ba44b59cbe5ffd7f2))

<a name="1.8.0"></a>
## [1.8.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.8.0) (2023-12-25)

### ✨ Features

* Maybe<T>.EmptyBind ([8e00797](https://www.github.com/kyleratti/FruityFoundation/commit/8e007975f66d83b9d3435149db361ae975ff0f91))

<a name="1.7.0"></a>
## [1.7.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.7.0) (2023-12-25)

### ✨ Features

* IEnumerable<T>.ConditionalAppend(Maybe<T>) ([de8d2f3](https://www.github.com/kyleratti/FruityFoundation/commit/de8d2f393c33a97e89fc461b28deebaaa6ccb3c3))

<a name="1.6.0"></a>
## [1.6.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.6.0) (2023-12-25)

### ✨ Features

* T?.AsMaybe() for reference types ([572c365](https://www.github.com/kyleratti/FruityFoundation/commit/572c365725eb1b746a30a3447a1e554b418b0372))

<a name="1.5.2"></a>
## [1.5.2](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.5.2) (2023-12-20)

### 🐛 Bug Fixes

* rename IDictionary.TryGet to TryGetValue ([b958542](https://www.github.com/kyleratti/FruityFoundation/commit/b95854253450ee2fe5f9a8df2c78f9e19a4732c8))

<a name="1.5.1"></a>
## [1.5.1](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.5.1) (2023-12-17)

### 🐛 Bug Fixes

* use correct signature on bind ([ef3a54e](https://www.github.com/kyleratti/FruityFoundation/commit/ef3a54eae788c1c6134f210e34060d880ddd1823))

<a name="1.5.0"></a>
## [1.5.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.5.0) (2023-9-4)

### ✨ Features

* Array.toReadOnlyCollection ([1c200a9](https://www.github.com/kyleratti/FruityFoundation/commit/1c200a9fcab73f634711ca98b4578ad11205b570))

<a name="1.4.0"></a>
## [1.4.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.4.0) (2023-8-3)

### ✨ Features

* add IDictionary.TryGet to return Maybe<T> ([1b15162](https://www.github.com/kyleratti/FruityFoundation/commit/1b15162ba50a390c67872aa0ee56cbf461754c35))

<a name="1.3.1"></a>
## [1.3.1](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.3.1) (2023-8-3)

### 🐛 Bug Fixes

* remove duplicate Choose extension ([5a2bd69](https://www.github.com/kyleratti/FruityFoundation/commit/5a2bd690f76749df09262a251dd967bd22905158))

<a name="1.3.0"></a>
## [1.3.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.3.0) (2023-8-2)

### ✨ Features

* add Result.FailureVal and Result.SuccessVal ([35cc366](https://www.github.com/kyleratti/FruityFoundation/commit/35cc366856d20d77f9f1feaf56fa1bfde6dd6d27))

<a name="1.2.3"></a>
## [1.2.3](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.2.3) (2023-8-2)

<a name="1.2.2"></a>
## [1.2.2](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.2.2) (2022-12-23)

### 🐛 Bug Fixes

* handle IEnumerable.Choose<TRefType> correctly (part 2) ([a0a8efb](https://www.github.com/kyleratti/FruityFoundation/commit/a0a8efb854d59d978d677d7a427e51392c9eb8e2))

<a name="1.2.1"></a>
## [1.2.1](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.2.1) (2022-12-23)

### 🐛 Bug Fixes

* handle IEnumerable.Choose<Nullable<TStruct>> correctly ([c17d3f1](https://www.github.com/kyleratti/FruityFoundation/commit/c17d3f10d47cc5ce4332b0a96155c5e9814a1a68))

<a name="1.2.0"></a>
## [1.2.0](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.2.0) (2022-12-23)

### ✨ Features

* add IEnumerable<T>.Choose for Maybe ([dafaae0](https://www.github.com/kyleratti/FruityFoundation/commit/dafaae0fabe1fc8c02e26a8b7a0c650ff261f807))
* add IEnumerable<T>.Choose() ([a045c76](https://www.github.com/kyleratti/FruityFoundation/commit/a045c76140d8e0b369ec6edc18548226e61a38af))

<a name="1.1.2"></a>
## [1.1.2](https://www.github.com/kyleratti/FruityFoundation/releases/tag/v1.1.2) (2022-12-1)

### ✨ Features

* add ByteHelper ([c39fdd8](https://www.github.com/kyleratti/FruityFoundation/commit/c39fdd86ec0d5c0639aed1149f4924aadf822363))
* add Enumerable.ConditionalConcat ([ea050f0](https://www.github.com/kyleratti/FruityFoundation/commit/ea050f098aa50c95b04fb098d07aecb666d577f8))
* add Enumerable.ConditionalWhere ([f3f511a](https://www.github.com/kyleratti/FruityFoundation/commit/f3f511ad3690216e3f59fe99c8c4a12de56c476e))
* add OneOf ([cdcfd67](https://www.github.com/kyleratti/FruityFoundation/commit/cdcfd671f01e683a763651ff74e927a46a429efb))
* move FSharp stuff into FsBase ([e12137b](https://www.github.com/kyleratti/FruityFoundation/commit/e12137b3021d94e329c7bf866b97018613f983bf))

### 🐛 Bug Fixes

* correct implementation of FirstOrEmpty ([5981dd0](https://www.github.com/kyleratti/FruityFoundation/commit/5981dd081dc5a56ae05543e6d19e295ac1321893))

