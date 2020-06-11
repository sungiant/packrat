#!/bin/bash

set -x #echo on

rm -rf bin/
mkdir bin/

cp packages/NUnit.2.6.4/lib/nunit.framework.dll bin/

mcs \
-unsafe \
-debug \
-define:DEBUG \
-out:bin/packrat.dll \
-target:library \
-recurse:source/src/Packrat.cs \
/doc:bin/packrat.xml \
-lib:bin/

mcs \
-unsafe \
-debug \
-define:DEBUG \
-out:bin/packrat.test.dll \
-target:library \
-recurse:source/src/Packrat.Tests.cs \
-lib:bin/ \
-lib:packages/NUnit.2.6.4/lib \
-reference:packrat.dll \
-reference:nunit.framework.dll
