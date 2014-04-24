Mono Assembly Resolve Issue
===========================

There's a difference between how mono and the .NET CLR works with respect to assembly resolve events firing. It seems like mono
is somehow remembering where it loaded previous assemblies from (the relative path) and not firing resolve for 
subsequent implicit loads if the assembly is in the same directory.

## How to run

### On OSX (haven't tried nix but it'll probably work the same way)

```
Run make
cd mono
mono Program.exe
```

You should see:

```
AppDomain base path is /something/mono-assemblyresolve-issue/mono/
AssemblyResolve=TestLib1
Trying to load assembly from PATH=/something/mono-assemblyresolve-issue/mono/both/TestLib1.dll
testlib1.myclass2.foo()

```

### On Windows

Assuming you are running with csc on the path

```
build.cmd
cd windows
Program.exe
```

You should see:

```
AppDomain base path is c:\something\Mono-Assembly-Resolve-Issue\windows\
AssemblyResolve=TestLib1
Trying to load assembly from PATH=C:\something\Mono-Assembly-Resolve-Issue\windows\both\TestLib1.dll
AssemblyResolve=TestLib2
Trying to load assembly from PATH=C:\something\Mono-Assembly-Resolve-Issue\windows\both\TestLib2.dll
testlib1.myclass2.foo()
```

Notice the 2 clls to Assembly resolve VS the single call in mono

