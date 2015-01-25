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

### On Windows

Assuming you are running with csc on the path

```
build.cmd
cd windows
Program.exe
```


