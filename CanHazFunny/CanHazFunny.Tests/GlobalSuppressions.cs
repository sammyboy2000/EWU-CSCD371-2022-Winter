// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

//Underscores are included in test methods for naming clarity.
//PascalCase is violated by underscoring as well, so it is disabled here.
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.IJokeServiceTests.GetJoke_GivenHttpClient_ReturnsJoke")]
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.IJokeServiceTests.GetJoke_GivenHttpClient_ReturnsJoke")]
