[![Build Status](https://travis-ci.org/sungiant/packrat.png?branch=master)](https://travis-ci.org/sungiant/packrat)

Packrat is a library for packaging common graphical data types.

## Packrat

[![Build Status](https://travis-ci.org/sungiant/packrat.png?branch=master)](https://travis-ci.org/sungiant/packrat)
[![Gitter](https://img.shields.io/badge/gitter-join%20chat-green.svg)](https://gitter.im/sungiant/packrat?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![License](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://raw.githubusercontent.com/sungiant/packrat/master/LICENSE)
[![Nuget Version](https://img.shields.io/nuget/v/Packrat.svg)](https://www.nuget.org/packages/Packrat)
[![Nuget Downloads](https://img.shields.io/nuget/dt/Packrat.svg)](https://www.nuget.org/packages/Packrat)

## Overview

Packrat is a library for packaging common graphical data types.

Packrat provides the following data type:

* Alpha 8
* BGR 5, 6, 5
* BGRA 16
* BGRA 5, 5, 5, 1
* Byte 4
* Normalised Byte 2
* Normalised Byte 4
* Normalised Short 2
* Normalised Short 4
* RG 32
* RGBA 32
* RGBA 64
* RGBA 10, 10, 10, 2
* Short 2
* Short 4

## Getting Started

Packrat is available as a stand-alone library via **[nuget][packrat_nuget]**.  Here's an example nuget `packages.config` file that pulls in Packrat:

```
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Packrat" version="0.9.0" targetFramework="net45" />
</packages>
```

Alternatively, given that all code is generated into a single source file, it is easy to simply copy the [Packrat.cs][sources] file straight into your project.

## License

Packrat is licensed under the **[MIT License][mit]**; you may not use this software except in compliance with the License.

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

[mit]: https://raw.githubusercontent.com/sungiant/packrat/master/LICENSE
[packrat_nuget]: https://www.nuget.org/packages/Packrat/
[sources]: https://github.com/sungiant/packrat/tree/master/source/packrat/src/main/cs
