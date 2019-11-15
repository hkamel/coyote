﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Coyote.Actors;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Coyote.TestingServices.Tests.Actors
{
    public class GotoStateExitFailTest : BaseTest
    {
        public GotoStateExitFailTest(ITestOutputHelper output)
            : base(output)
        {
        }

        private class M : StateMachine
        {
            [Start]
            [OnEntry(nameof(InitOnEntry))]
            [OnExit(nameof(ExitInit))]
            private class Init : State
            {
            }

            private void InitOnEntry()
            {
                this.Goto<Done>();
            }

            private void ExitInit()
            {
                // This assertion is reachable.
                this.Assert(false, "Reached test assertion.");
            }

            private class Done : State
            {
            }
        }

        [Fact(Timeout=5000)]
        public void TestGotoStateExitFail()
        {
            this.TestWithError(r =>
            {
                r.CreateActor(typeof(M));
            },
            expectedError: "Reached test assertion.",
            replay: true);
        }
    }
}