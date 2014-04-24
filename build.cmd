mkdir windows
mkdir windows\both
csc /target:exe /out:windows/Program.exe Program.cs
csc /target:library /out:windows\both\TestLib2.dll TestLib2.cs
csc /target:library /out:windows\both\TestLib1.dll /r:windows\both\TestLib2.dll TestLib1.cs

