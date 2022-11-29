// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using IdentityApiApi.Utility.Test;
using System;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<EfCoreTest>();
