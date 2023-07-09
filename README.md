# Monolythium
Making the legacy N-layer application more modular

This sample shown how possible to make N-layer monolyth applications modular without refactor their to onion-architecture.

Idea of this approach in making modules per each context and define their dependencies as is into every module. 
Some kind of composition root can load all moduels with their dependencies while the Root itself doesn't known abount modules dependencies and dependencies of dependencies.

Each module can depend on any other module (recursions are processed by IoC - Ninject in this case).

Features: composition root can define "local scope startegy". It allows to use modules in WebApi and thread-based services with defining different strategies (e.g. PerRequest or PerThread)
