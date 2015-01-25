Mono Assembly Resolve Issue
===========================

There's a difference between how mono and the .NET CLR works with respect to assembly resolve events firing. It seems like mono never sets the RequestingAssembly property which makes it hard to figure out which assembly is triggering the resolve event.

## How to run

### On OSX (haven't tried nix but it'll probably work the same way)

```
Run make
cd mono
mono Program.exe
```

Output

```
AppDomain base path is /Users/dfowler/dev/git/Mono-Assembly-Resolve-Issue/mono/
AssemblyResolve=TestLib1 from assembly 
Trying to load assembly from PATH=/Users/dfowler/dev/git/Mono-Assembly-Resolve-Issue/mono/both/TestLib1.dll
AssemblyResolve=TestLib2 from assembly 
Trying to load assembly from PATH=/Users/dfowler/dev/git/Mono-Assembly-Resolve-Issue/mono/both/TestLib2.dll
testlib1.myclass2.foo()
```

### On Windows

Assuming you are running with csc on the path

```
build.cmd
cd windows
Program.exe
```

Output

```
AppDomain base path is C:\dev\git\Mono-Assembly-Resolve-Issue\windows\
AssemblyResolve=TestLib1 from assembly
Trying to load assembly from PATH=C:\dev\git\Mono-Assembly-Resolve-Issue\windows\both\TestLib1.dll
AssemblyResolve=TestLib2 from assembly TestLib1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
Trying to load assembly from PATH=C:\dev\git\Mono-Assembly-Resolve-Issue\windows\both\TestLib2.dll
testlib1.myclass2.foo()
```
