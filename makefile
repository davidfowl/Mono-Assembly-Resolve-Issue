all: compile

prepare-output:
	mkdir -p both

compile: prepare-output
	mcs Program.cs /target:exe /out:Program.exe /r:"System;System.Core"
	mcs TestLib2.cs /target:library /out:both/TestLib2.dll /r:"System;System.Core"
	mcs TestLib1.cs /target:library /out:both/TestLib1.dll /r:"System;System.Core;both/TestLib2.dll"
