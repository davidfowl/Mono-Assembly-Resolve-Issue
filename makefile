all: compile

prepare-output:
	mkdir -p mono/both

compile: prepare-output
	mcs Program.cs /target:exe /out:mono/Program.exe /r:"System;System.Core"
	mcs TestLib2.cs /target:library /out:mono/both/TestLib2.dll /r:"System;System.Core"
	mcs TestLib1.cs /target:library /out:mono/both/TestLib1.dll /r:"System;System.Core;both/TestLib2.dll"
