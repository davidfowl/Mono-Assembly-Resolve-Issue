Mono Assembly Resolve Issue
===========================

There's a difference between how mono and the .NET CLR works with respect to assembly resolve events firing. It seems like mono
is somehow remembering where it loaded previous assemblies from (the relative path) and not firing resolve for 
subsequent implicit loads if the assembly is in the same directory.
