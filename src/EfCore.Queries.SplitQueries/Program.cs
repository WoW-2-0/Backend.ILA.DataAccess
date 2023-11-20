using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using EfCore.Queries.SplitQueries;

// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());

BenchmarkRunner.Run<Benchmark>();