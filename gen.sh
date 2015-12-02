#!/bin/bash

set -x

startPath=`pwd`

find . -name .DS_Store -exec rm -rf {} \;

cd source/packrat/gen/main

# tabs to spaces
find ./ ! -type d ! -name _tmp_ -exec sh -c 'expand -t 4 {} > _tmp_ && mv _tmp_ {}' \;

rm -rf ../../src/main/cs/*

# Generate Abacus.cs
mono ../../../../packages/Mono.TextTransform.1.0.0/tools/TextTransform.exe Packrat.tt -o ../../src/main/cs/Packrat.cs

cd $startPath

cd source/packrat/gen/test

# tabs to spaces
find ./ ! -type d ! -name _tmp_ -exec sh -c 'expand -t 4 {} > _tmp_ && mv _tmp_ {}' \;

rm -rf ../../src/test/cs/*

# Generate Tests.cs
mono ../../../../packages/Mono.TextTransform.1.0.0/tools/TextTransform.exe Packrat.Tests.tt -o ../../src/test/cs/Packrat.Tests.cs

cd $startPath
