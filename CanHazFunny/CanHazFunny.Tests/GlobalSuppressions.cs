// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;
//Underscores are used in Test Methods appropriately, so warning is surppressed.
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "Names may use underscores in test classes.", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.Jester_InitializeHttpClient_Success")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.Jester_InitializeHttpClient_Success")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.GetJoke_ReturnsValidJoke_Success")]
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "Names may use underscores in test classes.", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.GetJoke_ReturnsValidJoke_Success")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.ScreenJoke_GivenValidJoke_Success")]
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.ScreenJoke_GivenValidJoke_Success")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.ScreenJoke_GivenInvalidJoke_Failure")]
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.ScreenJoke_GivenInvalidJoke_Failure")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.FindJoke_GivenFilters_Success")]
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>", Scope = "member", Target = "~M:CanHazFunny.Tests.JesterTests.FindJoke_GivenFilters_Success")]
