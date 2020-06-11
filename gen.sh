#!/bin/bash

set -x

startPath=`pwd`

find . -name .DS_Store -exec rm -rf {} \;

cd source/gen/main

# tabs to spaces
find ./ ! -type d ! -name _tmp_ -exec sh -c 'expand -t 4 {} > _tmp_ && mv _tmp_ {}' \;

rm ../../src/Packrat.cs

# Generate Packrat.cs
mono ../../../packages/Mono.TextTransform.1.0.0/tools/TextTransform.exe -r 'System.Core' Packrat.tt -o ../../src/Packrat.cs

cd $startPath

cd source/gen/test

# tabs to spaces
find ./ ! -type d ! -name _tmp_ -exec sh -c 'expand -t 4 {} > _tmp_ && mv _tmp_ {}' \;

rm ../../src/Packrat.Tests.cs

# Generate Packrat.Tests.cs
mono ../../../packages/Mono.TextTransform.1.0.0/tools/TextTransform.exe -r 'System.Core' Packrat.Tests.tt -o ../../src/Packrat.Tests.cs

cd $startPath
